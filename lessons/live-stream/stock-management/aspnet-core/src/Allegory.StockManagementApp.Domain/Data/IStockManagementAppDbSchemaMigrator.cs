using System.Threading.Tasks;

namespace Allegory.StockManagementApp.Data;

public interface IStockManagementAppDbSchemaMigrator
{
    Task MigrateAsync();
}
