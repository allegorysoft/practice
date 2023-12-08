using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;
using Allegory.StockManagement.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Allegory.StockManagement.Customers;

public class EfCoreCustomerRepository
    : EfCoreRepository<StockManagementDbContext, Customer, Guid>, ICustomerRepository
{
    public EfCoreCustomerRepository(IDbContextProvider<StockManagementDbContext> dbContextProvider)
        : base(dbContextProvider)
    {
    }

    public async Task<Customer?> FindByCodeAsync(string code, CancellationToken cancellationToken = default)
    {
        IQueryable<Customer?> dbSet = await GetQueryableAsync();
        return await dbSet.FirstOrDefaultAsync(
            x => x.Code == code,
            GetCancellationToken(cancellationToken));
    }
}