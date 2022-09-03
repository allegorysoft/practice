using DynamicFilter.Entities;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace DynamicFilter.Services;

public class PersonAppService : CrudAppService<Person, PersonDto, Guid>
{
    public PersonAppService(IRepository<Person, Guid> personRepository) 
        : base(personRepository)
    {

    }
}
