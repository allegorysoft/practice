using Microsoft.EntityFrameworkCore;
using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.AuditLogging;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Identity;
using Volo.Abp.TenantManagement;
using Xunit;

namespace Allegory.SampleApp.EntityFrameworkCore.Samples;

/* This is just an example test class.
 * Normally, you don't test ABP framework code
 * (like default AppUser repository IRepository<AppUser, Guid> here).
 * Only test your custom repository methods.
 */
public class SampleRepositoryTests : SampleAppEntityFrameworkCoreTestBase
{
    private readonly IRepository<IdentityUser, Guid> _appUserRepository;
    private readonly IRepository<AuditLog, Guid> _auditLogRepository;
    private readonly IRepository<Tenant, Guid> _tenantRepository;

    public SampleRepositoryTests()
    {
        _appUserRepository = GetRequiredService<IRepository<IdentityUser, Guid>>();
        _auditLogRepository = GetRequiredService<IRepository<AuditLog, Guid>>();
        _tenantRepository = GetRequiredService<IRepository<Tenant, Guid>>();

    }

    [Fact]
    public async Task Should_Query_AppUser()
    {
        /* Need to manually start Unit Of Work because
         * FirstOrDefaultAsync should be executed while db connection / context is available.
         */
        await WithUnitOfWorkAsync(async () =>
        {
            //Act
            var adminUser = await (await _appUserRepository.GetQueryableAsync())
            .Where(u => u.UserName == "admin")
            .FirstOrDefaultAsync();

            //Assert
            adminUser.ShouldNotBeNull();
        });
    }

    [Fact]
    public async Task Should_Not_Join_Audit_To_User()
    {
        await Assert.ThrowsAsync<InvalidOperationException>(async () =>
        {
            await WithUnitOfWorkAsync(async () =>
            {
                var auditQueryable = await _auditLogRepository.GetQueryableAsync();
                var userQueryable = await _appUserRepository.GetQueryableAsync();

                var query = from user in userQueryable
                            join auditLog in auditQueryable on user.Id equals auditLog.UserId
                            select new { user, auditLog };

                var result = await query.ToListAsync();
            });
        });
    }

    [Fact]
    public async Task Should_Join_Tenant_To_User()
    {
        await WithUnitOfWorkAsync(async () =>
        {
            var tenantQueryable = await _tenantRepository.GetQueryableAsync();
            var userQueryable = await _appUserRepository.GetQueryableAsync();

            var query = from user in userQueryable
                        join tenant in tenantQueryable on user.Id equals tenant.CreatorId
                        select new { user, tenant };

            var result = await query.ToListAsync();

            Assert.NotNull(result);
        });
    }
}
