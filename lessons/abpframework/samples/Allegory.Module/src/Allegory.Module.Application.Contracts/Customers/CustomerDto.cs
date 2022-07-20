using System;
using Volo.Abp.Application.Dtos;

namespace Allegory.Module.Customers;

public class CustomerDto : EntityDto<Guid>
{
    public string Name { get; set; }
    public string Surname { get; set; }
}
