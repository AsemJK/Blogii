using Blogii.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace Blogii.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(BlogiiEntityFrameworkCoreModule),
    typeof(BlogiiApplicationContractsModule)
    )]
public class BlogiiDbMigratorModule : AbpModule
{
}
