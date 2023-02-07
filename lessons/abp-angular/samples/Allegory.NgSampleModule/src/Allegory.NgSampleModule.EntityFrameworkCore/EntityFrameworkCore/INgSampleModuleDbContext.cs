using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Allegory.NgSampleModule.EntityFrameworkCore;

[ConnectionStringName(NgSampleModuleDbProperties.ConnectionStringName)]
public interface INgSampleModuleDbContext : IEfCoreDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * DbSet<Question> Questions { get; }
     */
}
