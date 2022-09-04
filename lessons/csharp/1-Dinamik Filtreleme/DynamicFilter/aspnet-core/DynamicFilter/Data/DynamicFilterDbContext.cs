using DynamicFilter.Entities;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.IdentityServer.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement.EntityFrameworkCore;

namespace DynamicFilter.Data;

public class DynamicFilterDbContext : AbpDbContext<DynamicFilterDbContext>
{
    public DbSet<Person> People { get; set; }

    public DynamicFilterDbContext(DbContextOptions<DynamicFilterDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ConfigurePermissionManagement();
        builder.ConfigureSettingManagement();
        builder.ConfigureAuditLogging();
        builder.ConfigureIdentity();
        builder.ConfigureIdentityServer();
        builder.ConfigureFeatureManagement();
        builder.ConfigureTenantManagement();

        builder.Entity<Person>(b =>
        {
            b.ToTable("People");
            b.ConfigureByConvention();

            b.Property(p => p.Name).HasMaxLength(25).IsRequired();
            b.Property(p => p.Surname).HasMaxLength(25).IsRequired();
            b.Property(p => p.BirthDate).HasColumnType("date").IsRequired();
            b.Property(p => p.Gender).IsRequired();
            b.Property(p => p.Balance).HasColumnType("float").IsRequired();
        });
    }
}
