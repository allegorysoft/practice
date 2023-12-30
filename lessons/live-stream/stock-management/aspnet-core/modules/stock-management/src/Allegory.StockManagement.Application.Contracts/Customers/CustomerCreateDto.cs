using System.ComponentModel.DataAnnotations;
using Volo.Abp.Validation;

namespace Allegory.StockManagement.Customers;

public class CustomerCreateDto
{
    [Required]
    [DynamicStringLength(typeof(CustomerConsts), nameof(CustomerConsts.MaxCodeLength),
        nameof(CustomerConsts.MinCodeLength))]
    public string Code { get; set; } = null!;

    [DynamicStringLength(typeof(CustomerConsts), nameof(CustomerConsts.MaxNameLength))]
    public string? Name { get; set; }
}