using Microsoft.EntityFrameworkCore;
using Volo.Abp.DependencyInjection;

namespace DynamicFilter.Data;

public class DynamicFilterEFCoreDbSchemaMigrator : ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public DynamicFilterEFCoreDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the DynamicFilterDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<DynamicFilterDbContext>()
            .Database
            .MigrateAsync();
    }
}
