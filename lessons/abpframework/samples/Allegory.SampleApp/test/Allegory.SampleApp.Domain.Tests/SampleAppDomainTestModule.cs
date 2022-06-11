using Allegory.SampleApp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Allegory.SampleApp;

[DependsOn(
    typeof(SampleAppEntityFrameworkCoreTestModule)
    )]
public class SampleAppDomainTestModule : AbpModule
{

}
