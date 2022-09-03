using Volo.Abp.Domain.Entities;

namespace DynamicFilter.Entities;

public class Person : BasicAggregateRoot<Guid>
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public DateTime BirthDate { get; set; }
    public Gender Gender { get; set; }
    public decimal Balance { get; set; }

    public Person(Guid id) : base(id)
    {
       
    }
}

public enum Gender
{
    Male,
    Female
}
