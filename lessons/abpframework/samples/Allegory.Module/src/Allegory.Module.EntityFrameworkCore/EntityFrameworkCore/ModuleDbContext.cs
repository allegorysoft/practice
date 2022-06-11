using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Allegory.Module.EntityFrameworkCore;

[ConnectionStringName(ModuleDbProperties.ConnectionStringName)]
public class ModuleDbContext : AbpDbContext<ModuleDbContext>, IModuleDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * public DbSet<Question> Questions { get; set; }
     */

    public ModuleDbContext(DbContextOptions<ModuleDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ConfigureModule();
    }
}
