using Volo.Abp.Modularity;

namespace Allegory.StockManagement;

[DependsOn(
    typeof(StockManagementApplicationModule),
    typeof(StockManagementDomainTestModule)
    )]
public class StockManagementApplicationTestModule : AbpModule
{

}
