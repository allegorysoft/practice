using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Allegory.Module.EntityFrameworkCore;

public class ModuleHttpApiHostMigrationsDbContext : AbpDbContext<ModuleHttpApiHostMigrationsDbContext>
{
    public ModuleHttpApiHostMigrationsDbContext(DbContextOptions<ModuleHttpApiHostMigrationsDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ConfigureModule();
    }
}
