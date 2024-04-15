using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Blogii.Data;
using Volo.Abp.DependencyInjection;

namespace Blogii.EntityFrameworkCore;

public class EntityFrameworkCoreBlogiiDbSchemaMigrator
    : IBlogiiDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreBlogiiDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolve the BlogiiDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<BlogiiDbContext>()
            .Database
            .MigrateAsync();
    }
}
