using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Allegory.StockManagement.EntityFrameworkCore;

[ConnectionStringName(StockManagementDbProperties.ConnectionStringName)]
public class StockManagementDbContext : AbpDbContext<StockManagementDbContext>, IStockManagementDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * public DbSet<Question> Questions { get; set; }
     */

    public StockManagementDbContext(DbContextOptions<StockManagementDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ConfigureStockManagement();
    }
}
