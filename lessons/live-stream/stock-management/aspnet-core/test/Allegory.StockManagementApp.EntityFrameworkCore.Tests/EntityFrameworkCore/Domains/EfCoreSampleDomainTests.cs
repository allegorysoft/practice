using Allegory.StockManagementApp.Samples;
using Xunit;

namespace Allegory.StockManagementApp.EntityFrameworkCore.Domains;

[Collection(StockManagementAppTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<StockManagementAppEntityFrameworkCoreTestModule>
{

}
