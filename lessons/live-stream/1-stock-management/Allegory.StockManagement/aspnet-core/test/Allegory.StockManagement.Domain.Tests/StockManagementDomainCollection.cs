using Allegory.StockManagement.EntityFrameworkCore;
using Xunit;

namespace Allegory.StockManagement;

[CollectionDefinition(StockManagementTestConsts.CollectionDefinitionName)]
public class StockManagementDomainCollection : StockManagementEntityFrameworkCoreCollectionFixtureBase
{

}
