using Bogus;
using DynamicFilter.Entities;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Guids;
using Person = DynamicFilter.Entities.Person;

namespace DynamicFilter.Data;

public class PersonDataSeedContributor : IDataSeedContributor, ITransientDependency
{
    private readonly IRepository<Person, Guid> _personRepository;
    private readonly IGuidGenerator _guidGenerator;

    public PersonDataSeedContributor(
        IRepository<Person, Guid> personRepository,
        IGuidGenerator guidGenerator)
    {
        _personRepository = personRepository;
        _guidGenerator = guidGenerator;
    }

    public async Task SeedAsync(DataSeedContext context)
    {
        var people = new Faker<Person>("tr")
            .CustomInstantiator(f => new Person(_guidGenerator.Create()))
            .RuleFor(u => u.Gender, f => f.PickRandom<Gender>())
            .RuleFor(u => u.Name, (f, u) => f.Name.FirstName(ConvertToBogusGender(u.Gender)))
            .RuleFor(u => u.Surname, (f, u) => f.Name.LastName(ConvertToBogusGender(u.Gender)))
            .RuleFor(u => u.BirthDate, f => f.Date.Between(DateTime.Now.Date.AddYears(-50), DateTime.Now.Date))
            .RuleFor(u => u.Balance, f => f.Finance.Amount(-100_000, 100_000))
            .Generate(10000);

        await _personRepository.InsertManyAsync(people);
    }

    private Bogus.DataSets.Name.Gender ConvertToBogusGender(Gender gender)
    {
        switch (gender)
        {
            case Gender.Male:
                return Bogus.DataSets.Name.Gender.Male;
            default:
                return Bogus.DataSets.Name.Gender.Female;
        }
    }
}
