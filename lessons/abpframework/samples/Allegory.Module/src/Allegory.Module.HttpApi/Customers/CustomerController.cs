using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;

namespace Allegory.Module.Customers;

[RemoteService(Name = ModuleRemoteServiceConsts.RemoteServiceName)]
[Area(ModuleRemoteServiceConsts.ModuleName)]
[ControllerName("Customer")]
[Route("api/module/customers")]
public class CustomerController : ModuleController, ICustomerAppService
{
    protected ICustomerAppService CustomerAppService { get; }

    public CustomerController(ICustomerAppService customerAppService)
    {
        CustomerAppService = customerAppService;
    }

    [HttpGet]
    [Route("{id}")]
    public virtual Task<CustomerWithDetailsDto> GetAsync(Guid id)
    {
        return CustomerAppService.GetAsync(id);
    }

    [HttpGet]
    public virtual Task<PagedResultDto<CustomerDto>> GetListAsync(GetCustomerListDto input)
    {
        return CustomerAppService.GetListAsync(input);
    }

    [HttpPost]
    public virtual Task<CustomerWithDetailsDto> CreateAsync(CustomerCreateDto input)
    {
        return CustomerAppService.CreateAsync(input);
    }

    [HttpPut]
    [Route("{id}")]
    public virtual Task<CustomerWithDetailsDto> UpdateAsync(Guid id, CustomerUpdateDto input)
    {
        return CustomerAppService.UpdateAsync(id, input);
    }

    [HttpDelete]
    [Route("{id}")]
    public virtual Task DeleteAsync(Guid id)
    {
        return CustomerAppService.DeleteAsync(id);
    }
}
