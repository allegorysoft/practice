using Allegory.Module.Customers;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Allegory.Module.EntityFrameworkCore;

public static class ModuleDbContextModelCreatingExtensions
{
    public static void ConfigureModule(
        this ModelBuilder builder)
    {
        Check.NotNull(builder, nameof(builder));

        builder.Entity<Customer>(b =>
        {
            b.ToTable(ModuleDbProperties.DbTablePrefix + "Customers", ModuleDbProperties.DbSchema);
            b.ConfigureByConvention();

            b.Property(a => a.Name)
             .HasMaxLength(CustomerConsts.MaxNameLength)
             .IsRequired();
            b.Property(a => a.Surname)
             .HasMaxLength(CustomerConsts.MaxSurnameLength)
             .IsRequired();

            b.OwnsOne(a => a.Address);
            b.HasMany(a => a.ContactInformations)
             .WithOne()
             .HasForeignKey(f => f.CustomerId);
        });

        builder.Entity<ContactInformation>(b =>
        {
            b.ToTable(ModuleDbProperties.DbTablePrefix + "ContactInformations", ModuleDbProperties.DbSchema);
            b.ConfigureByConvention();

            b.HasKey(k => new { k.CustomerId, k.Name });
            b.Property(a => a.Name)
             .HasMaxLength(ContactInformationConsts.MaxNameLength)
             .IsRequired();
            b.Property(a => a.Value)
             .HasMaxLength(ContactInformationConsts.MaxValueLength)
             .IsRequired();
        });
    }
}
