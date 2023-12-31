using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;

namespace Allegory.StockManagement;

[DependsOn(
    typeof(StockManagementDomainSharedModule),
    typeof(AbpDddApplicationContractsModule),
    typeof(AbpAuthorizationModule)
    )]
public class StockManagementApplicationContractsModule : AbpModule
{

}
