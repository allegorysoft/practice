using Allegory.Module.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Allegory.Module;

/* Domain tests are configured to use the EF Core provider.
 * You can switch to MongoDB, however your domain tests should be
 * database independent anyway.
 */
[DependsOn(
    typeof(ModuleEntityFrameworkCoreTestModule)
    )]
public class ModuleDomainTestModule : AbpModule
{

}
