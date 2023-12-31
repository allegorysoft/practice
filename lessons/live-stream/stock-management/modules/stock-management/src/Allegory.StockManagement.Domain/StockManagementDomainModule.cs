using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace Allegory.StockManagement;

[DependsOn(
    typeof(AbpDddDomainModule),
    typeof(StockManagementDomainSharedModule)
)]
public class StockManagementDomainModule : AbpModule
{

}
