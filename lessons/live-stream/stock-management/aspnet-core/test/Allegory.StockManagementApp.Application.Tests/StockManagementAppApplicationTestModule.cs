using Volo.Abp.Modularity;

namespace Allegory.StockManagementApp;

[DependsOn(
    typeof(StockManagementAppApplicationModule),
    typeof(StockManagementAppDomainTestModule)
)]
public class StockManagementAppApplicationTestModule : AbpModule
{

}
