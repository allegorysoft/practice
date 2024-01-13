using Allegory.StockManagementApp.Samples;
using Xunit;

namespace Allegory.StockManagementApp.EntityFrameworkCore.Applications;

[Collection(StockManagementAppTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<StockManagementAppEntityFrameworkCoreTestModule>
{

}
