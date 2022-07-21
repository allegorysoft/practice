using System.ComponentModel.DataAnnotations;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Validation;

namespace Allegory.Module.Customers;

public class ContactInformationCreateUpdateDto : EntityDto
{
    [Required]
    [DynamicStringLength(typeof(ContactInformationConsts), nameof(ContactInformationConsts.MaxNameLength))]
    public string Name { get; set; }

    [Required]
    [EnumDataType(typeof(ContactInformationType))]
    public ContactInformationType Type { get; set; }

    [Required]
    [DynamicStringLength(typeof(ContactInformationConsts), nameof(ContactInformationConsts.MaxValueLength))]
    public string Value { get; set; }
}
