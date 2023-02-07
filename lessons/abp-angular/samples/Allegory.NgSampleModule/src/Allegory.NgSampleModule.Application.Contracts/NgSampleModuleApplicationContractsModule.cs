using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;

namespace Allegory.NgSampleModule;

[DependsOn(
    typeof(NgSampleModuleDomainSharedModule),
    typeof(AbpDddApplicationContractsModule),
    typeof(AbpAuthorizationModule)
    )]
public class NgSampleModuleApplicationContractsModule : AbpModule
{

}
