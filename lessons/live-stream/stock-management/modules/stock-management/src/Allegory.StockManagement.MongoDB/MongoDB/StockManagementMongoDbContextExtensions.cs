using Volo.Abp;
using Volo.Abp.MongoDB;

namespace Allegory.StockManagement.MongoDB;

public static class StockManagementMongoDbContextExtensions
{
    public static void ConfigureStockManagement(
        this IMongoModelBuilder builder)
    {
        Check.NotNull(builder, nameof(builder));
    }
}
