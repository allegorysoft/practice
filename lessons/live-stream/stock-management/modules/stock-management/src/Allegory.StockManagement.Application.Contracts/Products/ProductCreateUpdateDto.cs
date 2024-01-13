using System.ComponentModel.DataAnnotations;
using Volo.Abp.Validation;

namespace Allegory.StockManagement.Products;

public class ProductCreateUpdateDto
{
    [Required]
    [DynamicStringLength(typeof(ProductConsts), nameof(ProductConsts.MaxCodeLength),
        nameof(ProductConsts.MinCodeLength))]
    public string Code { get; set; } = null!;

    [DynamicStringLength(typeof(ProductConsts), nameof(ProductConsts.MaxNameLength))]
    public string? Name { get; set; }
}