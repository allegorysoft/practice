using System;
using System.Collections.ObjectModel;
using Volo.Abp.Application.Dtos;

namespace Allegory.Module.Customers;

public class CustomerWithDetailsDto : ExtensibleEntityDto<Guid>
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string CustomerGroupCode { get; set; }
    public Collection<ContactInformationDto> ContactInformations { get; set; } = new();
    public AddressDto Address { get; set; } = new();
}
