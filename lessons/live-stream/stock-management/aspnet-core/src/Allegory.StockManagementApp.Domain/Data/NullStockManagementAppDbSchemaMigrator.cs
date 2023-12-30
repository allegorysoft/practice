using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Allegory.StockManagementApp.Data;

/* This is used if database provider does't define
 * IStockManagementAppDbSchemaMigrator implementation.
 */
public class NullStockManagementAppDbSchemaMigrator : IStockManagementAppDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
