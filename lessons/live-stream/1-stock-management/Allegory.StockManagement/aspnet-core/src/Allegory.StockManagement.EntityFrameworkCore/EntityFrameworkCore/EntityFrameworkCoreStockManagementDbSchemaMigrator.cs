using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Allegory.StockManagement.Data;
using Volo.Abp.DependencyInjection;

namespace Allegory.StockManagement.EntityFrameworkCore;

public class EntityFrameworkCoreStockManagementDbSchemaMigrator
    : IStockManagementDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreStockManagementDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolve the StockManagementDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<StockManagementDbContext>()
            .Database
            .MigrateAsync();
    }
}
