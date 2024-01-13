using Volo.Abp.Application.Dtos;

namespace Allegory.StockManagement.Products;

public class GetProductsInput : PagedAndSortedResultRequestDto
{
    public string? Filter { get; set; }
}