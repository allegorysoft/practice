using Volo.Abp.Modularity;

namespace Allegory.StockManagement;

[DependsOn(
    typeof(StockManagementDomainModule),
    typeof(StockManagementTestBaseModule)
)]
public class StockManagementDomainTestModule : AbpModule
{

}
