using Volo.Abp.Application.Dtos;

namespace DynamicFilter.Entities;

public class PersonDto : EntityDto<Guid>
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public DateTime BirthDate { get; set; }
    public Gender Gender { get; set; }
    public decimal Balance { get; set; }
}
