using Allegory.StockManagement.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Allegory.StockManagement;

[DependsOn(
    typeof(StockManagementEntityFrameworkCoreTestModule)
    )]
public class StockManagementDomainTestModule : AbpModule
{

}
