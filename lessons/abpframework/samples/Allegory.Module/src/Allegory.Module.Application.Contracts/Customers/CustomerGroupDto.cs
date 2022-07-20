using System;
using Volo.Abp.Application.Dtos;

namespace Allegory.Module.Customers;

public class CustomerGroupDto : ExtensibleEntityDto<Guid>
{
    public string Code { get; set; }
    public string Description { get; set; }
}
