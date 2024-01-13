using Xunit;

namespace Allegory.StockManagementApp.EntityFrameworkCore;

[CollectionDefinition(StockManagementAppTestConsts.CollectionDefinitionName)]
public class StockManagementAppEntityFrameworkCoreCollection : ICollectionFixture<StockManagementAppEntityFrameworkCoreFixture>
{

}
