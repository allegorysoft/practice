using MongoDB.Driver;
using Volo.Abp.AuditLogging;
using Volo.Abp.AuditLogging.MongoDB;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Identity;
using Volo.Abp.Identity.MongoDB;
using Volo.Abp.MongoDB;

namespace Allegory.SampleMongoApp.MongoDB;

[ConnectionStringName("Default")]
[ReplaceDbContext(typeof(IAbpIdentityMongoDbContext),typeof(IAuditLoggingMongoDbContext))]
public class SampleMongoAppMongoDbContext : AbpMongoDbContext,
    IAbpIdentityMongoDbContext,
    IAuditLoggingMongoDbContext
{
    public IMongoCollection<IdentityUser> Users => Collection<IdentityUser>();
    public IMongoCollection<IdentityRole> Roles => Collection<IdentityRole>();
    public IMongoCollection<IdentityClaimType> ClaimTypes => Collection<IdentityClaimType>();
    public IMongoCollection<OrganizationUnit> OrganizationUnits => Collection<OrganizationUnit>();
    public IMongoCollection<IdentitySecurityLog> SecurityLogs => Collection<IdentitySecurityLog>();
    public IMongoCollection<IdentityLinkUser> LinkUsers => Collection<IdentityLinkUser>();

    public IMongoCollection<AuditLog> AuditLogs => Collection<AuditLog>();

    protected override void CreateModel(IMongoModelBuilder modelBuilder)
    {
        base.CreateModel(modelBuilder);

        modelBuilder.ConfigureIdentity();
        modelBuilder.ConfigureAuditLogging();
    }
}
