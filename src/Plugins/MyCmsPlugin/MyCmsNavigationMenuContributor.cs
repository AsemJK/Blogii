using Microsoft.Extensions.DependencyInjection;
using MyCmsPlugin.Data;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Volo.Abp.UI.Navigation;

namespace MyCmsPlugin
{
    public class MyCmsNavigationMenuContributor : IMenuContributor
    {
        public Task ConfigureMenuAsync(MenuConfigurationContext context)
        {
            if (context.Menu.Name == StandardMenus.Main)
            {
                ConfigureCmsMenuAsync(context);
            }
            return Task.CompletedTask;
        }

        private async Task ConfigureCmsMenuAsync(MenuConfigurationContext context)
        {
            var _dbContextExtension = context.ServiceProvider.GetRequiredService<MyCmsPluginDbContextExtension>();

            var pagesList = _dbContextExtension.Pages.Select(p =>
            new { p.Slug, p.Title }).ToList();
            foreach (var page in pagesList)
            {
                context.Menu.Items.Add(
                    new ApplicationMenuItem(
                        "MyCmsPlugin.Pages." + page.Title,
                        page.Title,
                        url: "/" + page.Slug,
                        icon: "fas fa-file",
                        order: 1
                    )
                );
            }
        }
    }
}
