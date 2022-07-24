using Allegory.Module.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Allegory.Module.Customers;

public class EfCoreCustomerRepository : EfCoreRepository<IModuleDbContext, Customer, Guid>, ICustomerRepository
{
    public EfCoreCustomerRepository(IDbContextProvider<IModuleDbContext> dbContextProvider)
        : base(dbContextProvider)
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

    protected virtual async Task<IQueryable<CustomerWithDetails>> ApplyFilterAsync()
    {
        var dbContext = await GetDbContextAsync();

        var customerDbSet = await GetDbSetAsync();
        var customerGroupDbSet = dbContext.Set<CustomerGroup>();

        return from customer in customerDbSet

               join customerGroup in customerGroupDbSet on customer.CustomerGroupId equals customerGroup.Id into customerGroups
               from customerGroup in customerGroups.DefaultIfEmpty()

               select new CustomerWithDetails
               {
                   Id = customer.Id,
                   Name = customer.Name,
                   Surname = customer.Surname,
                   ContactInformations = customer.ContactInformations,
                   //Address = customer.Address,(Throws exception detail: https://github.com/dotnet/EntityFramework.Docs/issues/2205)
                   Address = new Address(
                       customer.Address.Country,
                       customer.Address.City,
                       customer.Address.Town,
                       customer.Address.Line1,
                       customer.Address.Line2),
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
        var dbSet = await GetDbSetAsync();

        return await dbSet
            .IncludeDetails(includeDetails)
            .WhereIf(!filter.IsNullOrWhiteSpace(), c => c.Name.Contains(filter))
            .OrderBy(sorting)
            .PageBy(skipCount, maxResultCount)
            .ToListAsync(GetCancellationToken(cancellationToken));
    }

    public virtual async Task<long> GetCountAsync(
        string filter = null,
        Guid? customerGroupId = null,
        Guid? excludeCustomerId = null,
        CancellationToken cancellationToken = default)
    {
        return await (await GetDbSetAsync())
            .WhereIf(!filter.IsNullOrWhiteSpace(), c => c.Name.Contains(filter))
            .WhereIf(customerGroupId.HasValue, customer => customer.CustomerGroupId == customerGroupId)
            .WhereIf(excludeCustomerId.HasValue, customer => customer.Id != excludeCustomerId)
            .LongCountAsync(GetCancellationToken(cancellationToken));
    }

    public override async Task<IQueryable<Customer>> WithDetailsAsync()
    {
        return (await GetQueryableAsync()).IncludeDetails();
    }
}
