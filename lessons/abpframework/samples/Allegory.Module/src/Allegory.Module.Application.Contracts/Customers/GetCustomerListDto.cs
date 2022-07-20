using Volo.Abp.Application.Dtos;

namespace Allegory.Module.Customers;

public class GetCustomerListDto : PagedAndSortedResultRequestDto
{
    public string Filter { get; set; }
}
