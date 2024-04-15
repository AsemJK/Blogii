using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Blogii.Data;

/* This is used if database provider does't define
 * IBlogiiDbSchemaMigrator implementation.
 */
public class NullBlogiiDbSchemaMigrator : IBlogiiDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
