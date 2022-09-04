using Allegory.Standart.Filter.Concrete;
using Dapper;
using DynamicFilter.Data;
using DynamicFilter.Entities;
using DynamicFilter.Services.Dtos;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace DynamicFilter.Services;

public class PersonAppService : ApplicationService
{
    private readonly IRepository<Person> _personRepository;
    public PersonAppService(IRepository<Person, Guid> personRepository)
    {
        _personRepository = personRepository;
    }

    public async Task<PagedResultDto<PersonDto>> ListAsync(FilteredPagedAndSortedResultRequestDto input)
    {
        if (input.Sorting.IsNullOrWhiteSpace()) input.Sorting = nameof(Person.Id);

        var queryable = await _personRepository.GetQueryableAsync();
        var predicate = input.Conditions.GetLambdaExpression<Person>();

        var query = queryable.WhereIf(predicate != null, predicate);

        var items = await AsyncExecuter.ToListAsync(
            query.OrderBy(input.Sorting)
                 .PageBy(input.SkipCount, input.MaxResultCount));

        var totalCount = await AsyncExecuter.LongCountAsync(query);

        return new PagedResultDto<PersonDto>(
            totalCount,
            ObjectMapper.Map<IReadOnlyList<Person>, IReadOnlyList<PersonDto>>(items));
    }

    public async Task<PagedResultDto<ComplexPersonDto>> ListComplexAsync(FilteredPagedAndSortedResultRequestDto input)
    {
        if (input.Sorting.IsNullOrWhiteSpace()) input.Sorting = nameof(ComplexPersonDto.Id);
        var queryable = await _personRepository.GetQueryableAsync();
        var predicate = input.Conditions.GetLambdaExpression<ComplexPersonDto>();

        var query = queryable
            .Select(m => new ComplexPersonDto
            {
                Id = m.Id,
                FullName = m.Name + " " + m.Surname,
                Age = DateTime.Now.Year - m.BirthDate.Year
            })
            .WhereIf(predicate != null, predicate);

        var items = await AsyncExecuter.ToListAsync(
            query.OrderBy(input.Sorting)
                 .PageBy(input.SkipCount, input.MaxResultCount));

        var totalCount = await AsyncExecuter.LongCountAsync(query);

        return new PagedResultDto<ComplexPersonDto>(totalCount, items);
    }

    public ListResultDto<PersonDto> ListWithRawSql(FilteredAndSortedResultRequestDto input)
    {
        var context = LazyServiceProvider.LazyGetRequiredService<DynamicFilterDbContext>();

        using (var connection = context.Database.GetDbConnection())
        {
            var query = string.Format(
                "SELECT * FROM People {0} {1}",
                input.Conditions.GetFilterQuery<Person>(out IDictionary<string, object> parameters),
                input.Sorting.GetFilterQuery<Person>());

            var items = connection.Query<Person>(query, parameters).ToList();

            return new ListResultDto<PersonDto>(ObjectMapper.Map<IReadOnlyList<Person>, IReadOnlyList<PersonDto>>(items));
        }
    }
}
