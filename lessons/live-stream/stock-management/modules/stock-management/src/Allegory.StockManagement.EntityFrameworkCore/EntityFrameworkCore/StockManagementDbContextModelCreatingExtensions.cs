using Allegory.StockManagement.Customers;
using Allegory.StockManagement.Products;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Allegory.StockManagement.EntityFrameworkCore;

public static class StockManagementDbContextModelCreatingExtensions
{
    public static void ConfigureStockManagement(
        this ModelBuilder builder)
    {
        Check.NotNull(builder, nameof(builder));

        builder.Entity<Customer>(b =>
        {
            b.ToTable(StockManagementDbProperties.DbTablePrefix + "Customers", StockManagementDbProperties.DbSchema);
            b.ConfigureByConvention();

            b
                .Property(q => q.Code)
                .IsRequired()
                .HasMaxLength(CustomerConsts.MaxCodeLength);

            b
                .Property(q => q.Name)
                .HasMaxLength(CustomerConsts.MaxNameLength);
        });

        builder.Entity<Product>(b =>
        {
            b.ToTable(StockManagementDbProperties.DbTablePrefix + "Products", StockManagementDbProperties.DbSchema);
            b.ConfigureByConvention();

            b
                .Property(q => q.Code)
                .IsRequired()
                .HasMaxLength(ProductConsts.MaxCodeLength);

            b
                .Property(q => q.Name)
                .HasMaxLength(ProductConsts.MaxNameLength);
        });
    }
}
