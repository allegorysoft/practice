using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace Allegory.StockManagement.MongoDB;

[ConnectionStringName(StockManagementDbProperties.ConnectionStringName)]
public class StockManagementMongoDbContext : AbpMongoDbContext, IStockManagementMongoDbContext
{
    /* Add mongo collections here. Example:
     * public IMongoCollection<Question> Questions => Collection<Question>();
     */

    protected override void CreateModel(IMongoModelBuilder modelBuilder)
    {
        base.CreateModel(modelBuilder);

        modelBuilder.ConfigureStockManagement();
    }
}
