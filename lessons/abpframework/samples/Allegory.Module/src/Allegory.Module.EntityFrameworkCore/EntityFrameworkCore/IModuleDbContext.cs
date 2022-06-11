using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Allegory.Module.EntityFrameworkCore;

[ConnectionStringName(ModuleDbProperties.ConnectionStringName)]
public interface IModuleDbContext : IEfCoreDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * DbSet<Question> Questions { get; }
     */
}
