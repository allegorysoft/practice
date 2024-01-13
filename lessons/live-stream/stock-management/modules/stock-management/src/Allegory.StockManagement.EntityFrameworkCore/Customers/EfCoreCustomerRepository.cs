using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Allegory.StockManagement.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Allegory.StockManagement.Customers;

public class EfCoreCustomerRepository : EfCoreRepository<IStockManagementDbContext, Customer, Guid>, ICustomerRepository
{
    public EfCoreCustomerRepository(IDbContextProvider<IStockManagementDbContext> dbContextProvider)
        : base(dbContextProvider)
    {
    }


    public async Task<Customer?> FindByCodeAsync(string code, CancellationToken cancellationToken = default)
    {
        IQueryable<Customer?> queryable = await GetQueryableAsync();
        return await queryable.FirstOrDefaultAsync(
            x => x.Code == code,
            cancellationToken: cancellationToken);
    }
}