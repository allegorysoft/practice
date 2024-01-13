using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace Allegory.StockManagement.MongoDB;

[ConnectionStringName(StockManagementDbProperties.ConnectionStringName)]
public interface IStockManagementMongoDbContext : IAbpMongoDbContext
{
    /* Define mongo collections here. Example:
     * IMongoCollection<Question> Questions { get; }
     */
}
