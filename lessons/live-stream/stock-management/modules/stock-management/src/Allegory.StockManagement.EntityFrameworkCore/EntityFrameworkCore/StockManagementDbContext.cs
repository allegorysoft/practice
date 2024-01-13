using Allegory.StockManagement.Customers;
using Allegory.StockManagement.Products;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Allegory.StockManagement.EntityFrameworkCore;

[ConnectionStringName(StockManagementDbProperties.ConnectionStringName)]
public class StockManagementDbContext : AbpDbContext<StockManagementDbContext>, IStockManagementDbContext
{
     public DbSet<Customer> Customers { get; set; }
     public DbSet<Product> Products { get; set; }

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
