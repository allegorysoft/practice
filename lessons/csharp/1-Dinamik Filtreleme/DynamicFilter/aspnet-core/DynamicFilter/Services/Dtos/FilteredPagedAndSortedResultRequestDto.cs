using Allegory.Standart.Filter.Concrete;
using Volo.Abp.Application.Dtos;

namespace DynamicFilter.Services.Dtos;

public class FilteredPagedAndSortedResultRequestDto : PagedAndSortedResultRequestDto
{
    public Condition Conditions { get; set; }
}
