using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyCmsPlugin.Data;
using MyCmsPlugin.Services;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared;
using Volo.Abp.Modularity;
using Volo.Abp.UI.Navigation;

namespace MyCmsPlugin
{
    [DependsOn(typeof(AbpAspNetCoreMvcUiThemeSharedModule))]
    public class MyCmsPluginModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            PreConfigure<IMvcBuilder>(mvcBuilder =>
            {
                //Add plugin assembly
                mvcBuilder.PartManager.ApplicationParts.Add(new AssemblyPart(typeof(MyCmsPluginModule).Assembly));

                //Add CompiledRazorAssemblyPart if the PlugIn module contains razor views.
                mvcBuilder.PartManager.ApplicationParts.Add(new CompiledRazorAssemblyPart(typeof(MyCmsPluginModule).Assembly));
            });


        }
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<MyCmsPluginDbContextExtension>(options =>
            {
                options.AddDefaultRepositories(includeAllEntities: true);
            });

            context.Services.AddTransient<MyCmsPluginService>();
            context.Services.AddTransient<IPageService, PageService>();
            ConfigureNavigationServices();
            base.ConfigureServices(context);
        }
        private void ConfigureNavigationServices()
        {
            Configure<AbpNavigationOptions>(options =>
            {
                options.MenuContributors.Add(new MyCmsNavigationMenuContributor());
            });
        }
        public override async void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            var myService = context.ServiceProvider
                .GetRequiredService<MyCmsPluginService>();

            myService.Initialize();

            var dbContext = context.ServiceProvider
                .GetRequiredService<MyCmsPluginDbContextExtension>();
            switch (dbContext.Database.ProviderName.ToString())
            {
                case "Microsoft.EntityFrameworkCore.Sqlite":
                    await dbContext.Database.ExecuteSqlRawAsync("CREATE TABLE IF NOT EXISTS CmsPages (Id INTEGER PRIMARY KEY AUTOINCREMENT, Title TEXT NOT NULL, Content TEXT NOT NULL,Slug VARCHAR(350) NOT NULL);");
                    break;
                case "Microsoft.EntityFrameworkCore.SqlServer":
                    await dbContext.Database.ExecuteSqlRawAsync("if not exists (select * from sysobjects where name='CmsPages' and xtype='U') CREATE TABLE CmsPages (Id INT PRIMARY KEY IDENTITY(1,1), Title NVARCHAR(250) NOT NULL, Content TEXT NOT NULL,Slug VARCHAR(350) NOT NULL);");
                    break;
                case "Microsoft.EntityFrameworkCore.MySql":
                    await dbContext.Database.ExecuteSqlRawAsync("CREATE TABLE IF NOT EXISTS CmsPages (Id INT PRIMARY KEY AUTO_INCREMENT, Title TEXT NOT NULL, Content TEXT NOT NULL,Slug VARCHAR(350) NOT NULL);");
                    break;
                case "Microsoft.EntityFrameworkCore.PostgreSQL":
                    await dbContext.Database.ExecuteSqlRawAsync("CREATE TABLE IF NOT EXISTS CmsPages (Id SERIAL PRIMARY KEY, Title TEXT NOT NULL, Content TEXT NOT NULL,Slug VARCHAR(350) NOT NULL);");
                    break;
                default:
                    break;
            }
            base.OnApplicationInitialization(context);
        }
    }
}
