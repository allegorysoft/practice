using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Allegory.StockManagement.Products;

public interface IProductRepository : IBasicRepository<Product, Guid>
{
    Task<Product?> FindByCodeAsync(string code, CancellationToken cancellationToken = default);

    Task<List<Product>> GetListAsync(
        string? filter = null,
        string? sorting = null,
        int maxResultCount = int.MaxValue,
        int skipCount = 0,
        CancellationToken cancellationToken = default);

    Task<long> GetCountAsync(
        string? filter = null,
        CancellationToken cancellationToken = default);
}