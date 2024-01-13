using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Allegory.StockManagement.EntityFrameworkCore;

public class StockManagementHttpApiHostMigrationsDbContext : AbpDbContext<StockManagementHttpApiHostMigrationsDbContext>
{
    public StockManagementHttpApiHostMigrationsDbContext(DbContextOptions<StockManagementHttpApiHostMigrationsDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ConfigureStockManagement();
    }
}
