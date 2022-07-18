using Allegory.Module.MongoDB;
using MongoDB.Driver.Linq;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.MongoDB;
using Volo.Abp.MongoDB;

namespace Allegory.Module.Customers;

public class MongoCustomerRepository : MongoDbRepository<IModuleMongoDbContext, Customer, Guid>, ICustomerRepository
{
    public MongoCustomerRepository(IMongoDbContextProvider<IModuleMongoDbContext> dbContextProvider) : base(dbContextProvider)
    {

    }

    public virtual async Task<long> GetCountAsync(
        Guid? customerGroupId = null,
        Guid? excludeCustomerId = null,
        CancellationToken cancellationToken = default)
    {
        return await (await GetMongoQueryableAsync(cancellationToken))
            .WhereIf<Customer, IMongoQueryable<Customer>>(customerGroupId.HasValue, customer => customer.CustomerGroupId == customerGroupId)
            .WhereIf<Customer, IMongoQueryable<Customer>>(excludeCustomerId.HasValue, customer => customer.Id != excludeCustomerId)
            .LongCountAsync(GetCancellationToken(cancellationToken));
    }
}
