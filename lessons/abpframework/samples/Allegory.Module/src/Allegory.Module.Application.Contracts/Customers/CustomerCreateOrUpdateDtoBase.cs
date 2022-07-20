using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Validation;

namespace Allegory.Module.Customers;

public abstract class CustomerCreateOrUpdateDtoBase : ExtensibleEntityDto
{
    [Required]
    [DynamicStringLength(typeof(CustomerConsts), nameof(CustomerConsts.MaxNameLength))]
    public string Name { get; set; }

    [Required]
    [DynamicStringLength(typeof(CustomerConsts), nameof(CustomerConsts.MaxSurnameLength))]
    public string Surname { get; set; }

    [DynamicStringLength(typeof(CustomerGroupConsts), nameof(CustomerGroupConsts.MaxCodeLength))]
    public string CustomerGroupCode { get; set; }

    public Collection<ContactInformationCreateUpdateDto> ContactInformations { get; set; } = new();

    public AddressDto Address { get; set; } = new();
}
