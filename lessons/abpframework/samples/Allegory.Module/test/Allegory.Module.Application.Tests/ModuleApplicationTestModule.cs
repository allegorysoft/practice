using Volo.Abp.Modularity;

namespace Allegory.Module;

[DependsOn(
    typeof(ModuleApplicationModule),
    typeof(ModuleDomainTestModule)
    )]
public class ModuleApplicationTestModule : AbpModule
{

}
