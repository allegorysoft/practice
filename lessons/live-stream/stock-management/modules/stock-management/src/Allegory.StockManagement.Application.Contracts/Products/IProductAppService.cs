using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Allegory.StockManagement.Products;

public interface IProductAppService
    : ICrudAppService<
        ProductDto,
        Guid,
        GetProductsInput,
        ProductCreateUpdateDto>
{
    Task<ProductDto> GetByCodeAsync(string code);
}