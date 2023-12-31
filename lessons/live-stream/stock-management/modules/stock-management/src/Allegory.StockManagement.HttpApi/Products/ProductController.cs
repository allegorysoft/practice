using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.Application.Dtos;

namespace Allegory.StockManagement.Products;

[RemoteService(Name = StockManagementRemoteServiceConsts.RemoteServiceName)]
[Area(StockManagementRemoteServiceConsts.ModuleName)]
[ControllerName("Products")]
[Route("api/stock-management/products")]
public class ProductController : StockManagementController, IProductAppService
{
    public IProductAppService ProductAppService { get; }

    public ProductController(IProductAppService productAppService)
    {
        ProductAppService = productAppService;
    }

    [HttpGet]
    public Task<PagedResultDto<ProductDto>> GetListAsync(GetProductsInput input)
    {
        return ProductAppService.GetListAsync(input);
    }

    [HttpGet]
    [Route("{id:guid}")]
    public Task<ProductDto> GetAsync(Guid id)
    {
        return ProductAppService.GetAsync(id);
    }

    [HttpGet]
    [Route("{code}")]
    public Task<ProductDto> GetByCodeAsync(string code)
    {
        return ProductAppService.GetByCodeAsync(code);
    }

    [HttpPost]
    public Task<ProductDto> CreateAsync(ProductCreateUpdateDto input)
    {
        return ProductAppService.CreateAsync(input);
    }

    [HttpPut]
    [Route("{id:guid}")]
    public Task<ProductDto> UpdateAsync(Guid id, ProductCreateUpdateDto input)
    {
        return ProductAppService.UpdateAsync(id, input);
    }

    [HttpDelete]
    [Route("{id:guid}")]
    public Task DeleteAsync(Guid id)
    {
        return ProductAppService.DeleteAsync(id);
    }
}