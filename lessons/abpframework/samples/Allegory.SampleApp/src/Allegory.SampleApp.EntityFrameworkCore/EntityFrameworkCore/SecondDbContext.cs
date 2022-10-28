using Microsoft.EntityFrameworkCore;
using Volo.Abp.AuditLogging;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.IdentityServer.EntityFrameworkCore;

namespace Allegory.SampleApp.EntityFrameworkCore;

[ConnectionStringName("AbpAuditLogging")]
[ReplaceDbContext(typeof(IAuditLoggingDbContext))]
public class SecondDbContext : AbpDbContext<SecondDbContext>, IAuditLoggingDbContext
{
    public SecondDbContext(DbContextOptions<SecondDbContext> options) : base(options)
    {

    }

    public DbSet<AuditLog> AuditLogs { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ConfigureAuditLogging();
        builder.ConfigureIdentityServer();
    }
}
