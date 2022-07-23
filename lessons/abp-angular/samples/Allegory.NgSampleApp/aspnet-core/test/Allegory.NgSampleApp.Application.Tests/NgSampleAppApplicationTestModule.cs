using Volo.Abp.Modularity;

namespace Allegory.NgSampleApp;

[DependsOn(
    typeof(NgSampleAppApplicationModule),
    typeof(NgSampleAppDomainTestModule)
    )]
public class NgSampleAppApplicationTestModule : AbpModule
{

}
