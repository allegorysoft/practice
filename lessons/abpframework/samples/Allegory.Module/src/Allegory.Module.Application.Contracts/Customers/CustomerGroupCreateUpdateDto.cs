using System.ComponentModel.DataAnnotations;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Validation;

namespace Allegory.Module.Customers;

public class CustomerGroupCreateUpdateDto : ExtensibleEntityDto
{
    [Required]
    [DynamicStringLength(typeof(CustomerGroupConsts), nameof(CustomerGroupConsts.MaxCodeLength))]
    public string Code { get; set; }

    [DynamicStringLength(typeof(CustomerGroupConsts), nameof(CustomerGroupConsts.MaxDescriptionLength))]
    public string Description { get; set; }
}
