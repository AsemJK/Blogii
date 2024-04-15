using Volo.Abp.Modularity;

namespace Blogii;

/* Inherit from this class for your domain layer tests. */
public abstract class BlogiiDomainTestBase<TStartupModule> : BlogiiTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
