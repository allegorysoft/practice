using System;
using System.Threading.Tasks;
using MongoDB.Driver.Linq;
using Shouldly;
using Volo.Abp.AuditLogging;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Identity;
using Volo.Abp.TenantManagement;
using Xunit;

namespace Allegory.SampleMongoApp.MongoDB.Samples;

/* This is just an example test class.
 * Normally, you don't test ABP framework code
 * (like default AppUser repository IRepository<AppUser, Guid> here).
 * Only test your custom repository methods.
 */
[Collection(SampleMongoAppTestConsts.CollectionDefinitionName)]
public class SampleRepositoryTests : SampleMongoAppMongoDbTestBase
{
    private readonly IRepository<IdentityUser, Guid> _appUserRepository;
    private readonly IRepository<AuditLog, Guid> _auditLogRepository;
    private readonly IRepository<Tenant, Guid> _tenantRepository;

    public SampleRepositoryTests()
    {
        _appUserRepository = GetRequiredService<IRepository<IdentityUser, Guid>>();
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
                var adminUser = await (await _appUserRepository.GetMongoQueryableAsync())
                .FirstOrDefaultAsync(u => u.UserName == "admin");

                //Assert
                adminUser.ShouldNotBeNull();
        });
    }
}
