using Volo.Abp.Modularity;

namespace Blogii;

[DependsOn(
    typeof(BlogiiDomainModule),
    typeof(BlogiiTestBaseModule)
)]
public class BlogiiDomainTestModule : AbpModule
{

}
