using Volo.Abp.Application.Dtos;

namespace Allegory.Module.Customers;

public class ContactInformationDto : EntityDto
{
    public string Name { get; set; }
    public ContactInformationType Type { get; set; }
    public string Value { get; set; }
}
