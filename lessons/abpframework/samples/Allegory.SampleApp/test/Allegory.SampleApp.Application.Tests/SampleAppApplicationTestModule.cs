using Volo.Abp.Modularity;

namespace Allegory.SampleApp;

[DependsOn(
    typeof(SampleAppApplicationModule),
    typeof(SampleAppDomainTestModule)
    )]
public class SampleAppApplicationTestModule : AbpModule
{

}
