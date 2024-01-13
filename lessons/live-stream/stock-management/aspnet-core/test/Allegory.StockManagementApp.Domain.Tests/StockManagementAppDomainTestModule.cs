using Volo.Abp.Modularity;

namespace Allegory.StockManagementApp;

[DependsOn(
    typeof(StockManagementAppDomainModule),
    typeof(StockManagementAppTestBaseModule)
)]
public class StockManagementAppDomainTestModule : AbpModule
{

}
