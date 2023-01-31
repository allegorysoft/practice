using Volo.Abp.Modularity;

namespace Allegory.NgSampleModule;

[DependsOn(
    typeof(NgSampleModuleApplicationModule),
    typeof(NgSampleModuleDomainTestModule)
    )]
public class NgSampleModuleApplicationTestModule : AbpModule
{

}
