using Allegory.NgSampleApp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Allegory.NgSampleApp;

[DependsOn(
    typeof(NgSampleAppEntityFrameworkCoreTestModule)
    )]
public class NgSampleAppDomainTestModule : AbpModule
{

}
