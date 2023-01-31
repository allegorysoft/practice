using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Allegory.NgSampleModule.EntityFrameworkCore;

public class NgSampleModuleHttpApiHostMigrationsDbContext : AbpDbContext<NgSampleModuleHttpApiHostMigrationsDbContext>
{
    public NgSampleModuleHttpApiHostMigrationsDbContext(DbContextOptions<NgSampleModuleHttpApiHostMigrationsDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ConfigureNgSampleModule();
    }
}
