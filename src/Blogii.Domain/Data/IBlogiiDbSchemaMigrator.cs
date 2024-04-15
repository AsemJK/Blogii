using System.Threading.Tasks;

namespace Blogii.Data;

public interface IBlogiiDbSchemaMigrator
{
    Task MigrateAsync();
}
