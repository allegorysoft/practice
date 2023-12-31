using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Allegory.StockManagement.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

namespace Allegory.StockManagement.Products;

public class EfCoreProductRepository : EfCoreRepository<IStockManagementDbContext, Product, Guid>, IProductRepository
{
    public EfCoreProductRepository(IDbContextProvider<IStockManagementDbContext> dbContextProvider)
        : base(dbContextProvider)
    {
    }

    public async Task<Product?> FindByCodeAsync(
        string code,
        CancellationToken cancellationToken = default)
    {
        var queryable = await GetQueryableAsync();

        return await queryable.FirstOrDefaultAsync(
            x => x.Code == code,
            cancellationToken: cancellationToken);
    }

    public async Task<List<Product>> GetListAsync(
        string? filter = null,
        string? sorting = null,
        int maxResultCount = int.MaxValue,
        int skipCount = 0,
        CancellationToken cancellationToken = default)
    {
        var query = ApplyFilter(await GetQueryableAsync(), filter);
        query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? nameof(Product.Code) : sorting);
        return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
    }

    public async Task<long> GetCountAsync(
        string? filter = null,
        CancellationToken cancellationToken = default)
    {
        var query = ApplyFilter(await GetDbSetAsync(), filter);
        return await query.LongCountAsync(GetCancellationToken(cancellationToken));
    }

    protected virtual IQueryable<Product> ApplyFilter(
        IQueryable<Product> query,
        string? filter)
    {
        return query
            .WhereIf(!string.IsNullOrWhiteSpace(filter), e => e.Code!.Contains(filter!));
    }
}