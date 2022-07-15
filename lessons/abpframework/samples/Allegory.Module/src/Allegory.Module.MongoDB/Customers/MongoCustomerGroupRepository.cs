using Allegory.Module.MongoDB;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.MongoDB;
using Volo.Abp.MongoDB;

namespace Allegory.Module.Customers;

public class MongoCustomerGroupRepository : MongoDbRepository<IModuleMongoDbContext, CustomerGroup, Guid>, ICustomerGroupRepository
{
    public MongoCustomerGroupRepository(IMongoDbContextProvider<IModuleMongoDbContext> dbContextProvider) : base(dbContextProvider)
    {

    }

    public virtual async Task<CustomerGroup> FindByCodeAsync(
        string code,
        bool includeDetails = true,
        CancellationToken cancellationToken = default)
    {
        return await (await GetMongoQueryableAsync(cancellationToken))
            .FirstOrDefaultAsync(cg => cg.Code == code,
            GetCancellationToken(cancellationToken));
    }
}
