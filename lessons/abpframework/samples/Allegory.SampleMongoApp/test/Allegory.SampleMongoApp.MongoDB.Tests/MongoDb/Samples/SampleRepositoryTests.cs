using MongoDB.Driver;
using MongoDB.Driver.Linq;
using Shouldly;
using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.AuditLogging;
using Volo.Abp.Data;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Identity;
using Volo.Abp.MultiTenancy;
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
    private readonly IDataFilter _dataFilter;

    public SampleRepositoryTests()
    {
        _appUserRepository = GetRequiredService<IRepository<IdentityUser, Guid>>();
        _auditLogRepository = GetRequiredService<IRepository<AuditLog, Guid>>();
        _dataFilter = GetRequiredService<IDataFilter>();
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

    [Fact]
    public async Task Should_Join_Audit_To_User()
    {
        using (_dataFilter.Disable<IMultiTenant>())
        {
            using (_dataFilter.Disable<ISoftDelete>())
            {
                var auditQueryable = await _auditLogRepository.GetMongoQueryableAsync();
                var userQueryable = await _appUserRepository.GetMongoQueryableAsync();

                var query = from user in userQueryable
                            join auditLog in auditQueryable on user.Id equals auditLog.UserId.Value
                            select new { user, auditLog };

                var result = await query.ToListAsync();

                result.ShouldNotBeNull();
            }
        }
    }

    [Fact]
    public async Task Should_Join_Audit_To_User_With_Collection_Method()
    {
        var auditQueryable = await _auditLogRepository.GetCollectionAsync();
        var userQueryable = await _appUserRepository.GetCollectionAsync();

        var query = from user in userQueryable.AsQueryable()
                    join auditLog in auditQueryable.AsQueryable() on user.Id equals auditLog.UserId.Value
                    select new { user, auditLog };

        var result = await query.ToListAsync();

        result.ShouldNotBeNull();
    }
}
