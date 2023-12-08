using System.ComponentModel.DataAnnotations;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Validation;

namespace Allegory.StockManagement.Customers;

public class CreateCustomerDto
{
    [Required]
    [DynamicStringLength(typeof(CustomerConsts), nameof(CustomerConsts.MaxCodeLength),
        nameof(CustomerConsts.MinCodeLength))]
    public string Code { get; set; } = null!;

    public string? Name { get; set; }
}