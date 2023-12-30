using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Allegory.StockManagementApp.Data;
using Volo.Abp.DependencyInjection;

namespace Allegory.StockManagementApp.EntityFrameworkCore;

public class EntityFrameworkCoreStockManagementAppDbSchemaMigrator
    : IStockManagementAppDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreStockManagementAppDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolve the StockManagementAppDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<StockManagementAppDbContext>()
            .Database
            .MigrateAsync();
    }
}
