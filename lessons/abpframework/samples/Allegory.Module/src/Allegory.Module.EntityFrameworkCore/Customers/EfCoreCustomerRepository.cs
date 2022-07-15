using Allegory.Module.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Allegory.Module.Customers;

public class EfCoreCustomerRepository : EfCoreRepository<IModuleDbContext, Customer, Guid>, ICustomerRepository
{
    public EfCoreCustomerRepository(IDbContextProvider<IModuleDbContext> dbContextProvider)
        : base(dbContextProvider)
    {

    }

    public virtual async Task<long> GetCountAsync(
        Guid? customerGroupId = null,
        Guid? excludeCustomerId = null,
        CancellationToken cancellationToken = default)
    {
        return await (await GetDbSetAsync())
            .WhereIf(customerGroupId.HasValue, customer => customer.CustomerGroupId == customerGroupId)
            .WhereIf(excludeCustomerId.HasValue, customer => customer.Id != excludeCustomerId)
            .LongCountAsync(GetCancellationToken(cancellationToken));
    }

    public override async Task<IQueryable<Customer>> WithDetailsAsync()
    {
        return (await GetQueryableAsync()).IncludeDetails();
    }
}
