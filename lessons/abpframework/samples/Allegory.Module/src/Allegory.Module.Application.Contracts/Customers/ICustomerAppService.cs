using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Allegory.Module.Customers;

public interface ICustomerAppService : IApplicationService
{
    Task<CustomerWithDetailsDto> GetAsync(Guid id);

    Task<PagedResultDto<CustomerDto>> GetListAsync(GetCustomerListDto input);

    Task<CustomerWithDetailsDto> CreateAsync(CustomerCreateDto input);

    Task<CustomerWithDetailsDto> UpdateAsync(Guid id, CustomerUpdateDto input);

    Task DeleteAsync(Guid id);
}
