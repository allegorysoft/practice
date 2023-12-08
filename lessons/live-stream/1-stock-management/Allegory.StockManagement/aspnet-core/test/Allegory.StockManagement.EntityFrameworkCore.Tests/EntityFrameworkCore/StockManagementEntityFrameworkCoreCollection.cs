using Xunit;

namespace Allegory.StockManagement.EntityFrameworkCore;

[CollectionDefinition(StockManagementTestConsts.CollectionDefinitionName)]
public class StockManagementEntityFrameworkCoreCollection : ICollectionFixture<StockManagementEntityFrameworkCoreFixture>
{

}
