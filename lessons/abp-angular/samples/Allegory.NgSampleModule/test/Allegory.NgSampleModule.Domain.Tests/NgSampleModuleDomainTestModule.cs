using Allegory.NgSampleModule.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Allegory.NgSampleModule;

/* Domain tests are configured to use the EF Core provider.
 * You can switch to MongoDB, however your domain tests should be
 * database independent anyway.
 */
[DependsOn(
    typeof(NgSampleModuleEntityFrameworkCoreTestModule)
    )]
public class NgSampleModuleDomainTestModule : AbpModule
{

}
