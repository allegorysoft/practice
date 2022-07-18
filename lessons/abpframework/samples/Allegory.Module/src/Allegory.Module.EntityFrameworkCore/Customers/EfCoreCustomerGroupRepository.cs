using Allegory.Module.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Allegory.Module.Customers;

public class EfCoreCustomerGroupRepository : EfCoreRepository<IModuleDbContext, CustomerGroup, Guid>, ICustomerGroupRepository
{
    public EfCoreCustomerGroupRepository(IDbContextProvider<IModuleDbContext> dbContextProvider)
        : base(dbContextProvider)
    {

    }

    public virtual async Task<CustomerGroup> FindByCodeAsync(
        string code,
        bool includeDetails = true,
        CancellationToken cancellationToken = default)
    {
        return await (await GetDbSetAsync())
            .FirstOrDefaultAsync(cg => cg.Code == code,
            GetCancellationToken(cancellationToken));
    }
}
