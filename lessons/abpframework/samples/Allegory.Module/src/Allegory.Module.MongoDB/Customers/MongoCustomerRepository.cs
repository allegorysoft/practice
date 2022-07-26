using Allegory.Module.MongoDB;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories.MongoDB;
using Volo.Abp.MongoDB;

namespace Allegory.Module.Customers;

public class MongoCustomerRepository : MongoDbRepository<IModuleMongoDbContext, Customer, Guid>, ICustomerRepository
{
    public MongoCustomerRepository(IMongoDbContextProvider<IModuleMongoDbContext> dbContextProvider) : base(dbContextProvider)
    {

    }

    public virtual async Task<CustomerWithDetails> GetWithDetailsAsync(
        Guid id,
        CancellationToken cancellationToken = default)
    {
        var query = await ApplyFilterAsync();

        var result = await query.FirstOrDefaultAsync(
            c => c.Id == id,
            GetCancellationToken(cancellationToken));

        if (result == null)
            throw new EntityNotFoundException(typeof(Customer), id);

        return result;
    }

    protected virtual async Task<IMongoQueryable<CustomerWithDetails>> ApplyFilterAsync()
    {
        var customerDbSet = await GetMongoQueryableAsync();
        var customerGroupDbSet = await GetMongoQueryableAsync<CustomerGroup>();

        return from customer in customerDbSet

               join customerGroup in customerGroupDbSet on customer.CustomerGroupId.Value equals customerGroup.Id into customerGroups
               from customerGroup in customerGroups.DefaultIfEmpty()

               select new CustomerWithDetails
               {
                   Id = customer.Id,
                   Name = customer.Name,
                   Surname = customer.Surname,
                   ContactInformations = customer.ContactInformations,
                   Address = customer.Address,
                   ExtraProperties = customer.ExtraProperties,
                   CustomerGroupCode = customerGroup.Code,
               };
    }

    public virtual async Task<List<Customer>> GetListAsync(
        int skipCount,
        int maxResultCount,
        string sorting,
        string filter = null,
        bool includeDetails = false,
        CancellationToken cancellationToken = default)
    {
        var dbSet = await GetMongoQueryableAsync();

        return await dbSet
            .WhereIf<Customer, IMongoQueryable<Customer>>(!filter.IsNullOrWhiteSpace(), c => c.Name.Contains(filter))
            .OrderBy(sorting)
            .As<IMongoQueryable<Customer>>()
            .PageBy<Customer, IMongoQueryable<Customer>>(skipCount, maxResultCount)
            .ToListAsync(GetCancellationToken(cancellationToken));
    }

    public virtual async Task<long> GetCountAsync(
        string filter = null,
        Guid? customerGroupId = null,
        Guid? excludeCustomerId = null,
        CancellationToken cancellationToken = default)
    {
        return await (await GetMongoQueryableAsync(cancellationToken))
            .WhereIf<Customer, IMongoQueryable<Customer>>(!filter.IsNullOrWhiteSpace(), customer => customer.Name.Contains(filter))
            .WhereIf<Customer, IMongoQueryable<Customer>>(customerGroupId.HasValue, customer => customer.CustomerGroupId == customerGroupId)
            .WhereIf<Customer, IMongoQueryable<Customer>>(excludeCustomerId.HasValue, customer => customer.Id != excludeCustomerId)
            .LongCountAsync(GetCancellationToken(cancellationToken));
    }
}
