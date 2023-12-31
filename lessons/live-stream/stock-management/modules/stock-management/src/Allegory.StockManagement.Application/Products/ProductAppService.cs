using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;

namespace Allegory.StockManagement.Products;

public class ProductAppService : StockManagementAppService, IProductAppService
{
    public IProductRepository ProductRepository { get; }
    public ProductManager ProductManager { get; }

    public ProductAppService(
        IProductRepository repository,
        ProductManager productManager)
    {
        ProductRepository = repository;
        ProductManager = productManager;
    }

    public virtual async Task<PagedResultDto<ProductDto>> GetListAsync(GetProductsInput input)
    {
        var totalCount = await ProductRepository.GetCountAsync(input.Filter);
        var items = await ProductRepository.GetListAsync(
            input.Filter,
            input.Sorting,
            input.MaxResultCount,
            input.SkipCount);

        return new PagedResultDto<ProductDto>(
            totalCount,
            ObjectMapper.Map<List<Product>, List<ProductDto>>(items));
    }

    public virtual async Task<ProductDto> GetAsync(Guid id)
    {
        var product = await ProductRepository.GetAsync(id);
        return ObjectMapper.Map<Product, ProductDto>(product);
    }

    public async Task<ProductDto> GetByCodeAsync(string code)
    {
        var product = await ProductRepository.FindByCodeAsync(code);

        if (product == null)
        {
            throw new UserFriendlyException($"{code} kodlu ürün bulunamadı.");
        }

        return ObjectMapper.Map<Product, ProductDto>(product);
    }

    public virtual async Task<ProductDto> CreateAsync(ProductCreateUpdateDto input)
    {
        var product = await ProductManager.CreateAsync(input.Code);
        product.SetName(input.Name);
        await ProductRepository.InsertAsync(product);
        return ObjectMapper.Map<Product, ProductDto>(product);
    }

    public virtual async Task<ProductDto> UpdateAsync(Guid id, ProductCreateUpdateDto input)
    {
        var product = await ProductRepository.GetAsync(id);

        await ProductManager.ChangeCodeAsync(product, input.Code);
        product.SetName(input.Name);

        await ProductRepository.UpdateAsync(product);
        return ObjectMapper.Map<Product, ProductDto>(product);
    }

    public virtual async Task DeleteAsync(Guid id)
    {
        await ProductRepository.DeleteAsync(id);
    }
}