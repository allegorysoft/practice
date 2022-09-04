using Allegory.Standart.Filter.Concrete;

namespace DynamicFilter.Services.Dtos;

public class FilteredAndSortedResultRequestDto
{
    public Condition Conditions { get; set; }
    public Sort Sorting { get; set; }
}
