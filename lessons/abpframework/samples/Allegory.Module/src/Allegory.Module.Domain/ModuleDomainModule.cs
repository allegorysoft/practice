using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace Allegory.Module;

[DependsOn(
    typeof(AbpDddDomainModule),
    typeof(ModuleDomainSharedModule)
)]
public class ModuleDomainModule : AbpModule
{

}
