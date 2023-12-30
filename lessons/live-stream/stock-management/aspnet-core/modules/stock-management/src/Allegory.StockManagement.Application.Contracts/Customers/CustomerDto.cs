using System;
using Volo.Abp.Application.Dtos;

namespace Allegory.StockManagement.Customers;

public class CustomerDto : EntityDto<Guid>
{
    public string Code { get; set; } = null!;
    public string? Name { get; set; }
}