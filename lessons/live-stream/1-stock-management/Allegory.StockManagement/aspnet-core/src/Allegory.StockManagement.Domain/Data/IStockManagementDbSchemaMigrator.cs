using System.Threading.Tasks;

namespace Allegory.StockManagement.Data;

public interface IStockManagementDbSchemaMigrator
{
    Task MigrateAsync();
}
