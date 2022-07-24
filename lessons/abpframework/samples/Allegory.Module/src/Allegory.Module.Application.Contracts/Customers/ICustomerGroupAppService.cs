using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Allegory.Module.Customers;

public interface ICustomerGroupAppService : IApplicationService
{
    Task<CustomerGroupDto> GetAsync(Guid id);

    Task<CustomerGroupDto> GetByCodeAsync(string code);

    Task<PagedResultDto<CustomerGroupDto>> GetListAsync(PagedAndSortedResultRequestDto input);

    Task<CustomerGroupDto> CreateAsync(CustomerGroupCreateUpdateDto input);

    Task<CustomerGroupDto> UpdateAsync(Guid id, CustomerGroupCreateUpdateDto input);

    Task DeleteAsync(Guid id);
}
