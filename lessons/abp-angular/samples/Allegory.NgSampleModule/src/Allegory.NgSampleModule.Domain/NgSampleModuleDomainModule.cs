using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace Allegory.NgSampleModule;

[DependsOn(
    typeof(AbpDddDomainModule),
    typeof(NgSampleModuleDomainSharedModule)
)]
public class NgSampleModuleDomainModule : AbpModule
{

}
