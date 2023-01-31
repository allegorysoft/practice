using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Allegory.NgSampleModule.EntityFrameworkCore;

[ConnectionStringName(NgSampleModuleDbProperties.ConnectionStringName)]
public class NgSampleModuleDbContext : AbpDbContext<NgSampleModuleDbContext>, INgSampleModuleDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * public DbSet<Question> Questions { get; set; }
     */

    public NgSampleModuleDbContext(DbContextOptions<NgSampleModuleDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ConfigureNgSampleModule();
    }
}
