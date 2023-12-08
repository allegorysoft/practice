using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Allegory.StockManagement.Data;

/* This is used if database provider does't define
 * IStockManagementDbSchemaMigrator implementation.
 */
public class NullStockManagementDbSchemaMigrator : IStockManagementDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
