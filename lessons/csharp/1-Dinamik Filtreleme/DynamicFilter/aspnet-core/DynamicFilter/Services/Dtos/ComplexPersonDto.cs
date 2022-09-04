using DynamicFilter.Entities;
using Volo.Abp.Application.Dtos;

namespace DynamicFilter.Services.Dtos;

public class ComplexPersonDto : EntityDto<Guid>
{
    public string FullName { get; set; }
    public int Age { get; set; }
}
