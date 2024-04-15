using Volo.Abp.Modularity;

namespace Blogii;

[DependsOn(
    typeof(BlogiiApplicationModule),
    typeof(BlogiiDomainTestModule)
)]
public class BlogiiApplicationTestModule : AbpModule
{

}
