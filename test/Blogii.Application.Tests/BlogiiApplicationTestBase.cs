using Volo.Abp.Modularity;

namespace Blogii;

public abstract class BlogiiApplicationTestBase<TStartupModule> : BlogiiTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
