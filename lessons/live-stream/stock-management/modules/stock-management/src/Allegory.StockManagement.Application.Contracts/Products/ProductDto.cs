using System;
using Volo.Abp.Application.Dtos;

namespace Allegory.StockManagement.Products;

public class ProductDto: EntityDto<Guid>
{
    public string Code { get; set; } = null!;
    public string? Name { get; set; }
}