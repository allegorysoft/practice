using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;

namespace Allegory.Module.Customers;

[RemoteService(Name = ModuleRemoteServiceConsts.RemoteServiceName)]
[Area(ModuleRemoteServiceConsts.ModuleName)]
[ControllerName("Customer")]
[Route("api/module/customer-groups")]
public class CustomerGroupController : ModuleController, ICustomerGroupAppService
{
    protected ICustomerGroupAppService CustomerGroupAppService { get; }

    public CustomerGroupController(ICustomerGroupAppService customerGroupAppService)
    {
        CustomerGroupAppService = customerGroupAppService;
    }

    [HttpGet]
    [Route("{id}")]
    public virtual Task<CustomerGroupDto> GetAsync(Guid id)
    {
        return CustomerGroupAppService.GetAsync(id);
    }

    [HttpGet]
    [Route("by-code")]
    public virtual Task<CustomerGroupDto> GetByCodeAsync(string code)
    {
        return CustomerGroupAppService.GetByCodeAsync(code);
    }

    [HttpGet]
    public virtual Task<PagedResultDto<CustomerGroupDto>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        return CustomerGroupAppService.GetListAsync(input);
    }

    [HttpPost]
    public virtual Task<CustomerGroupDto> CreateAsync(CustomerGroupCreateUpdateDto input)
    {
        return CustomerGroupAppService.CreateAsync(input);
    }

    [HttpPut]
    [Route("{id}")]
    public virtual Task<CustomerGroupDto> UpdateAsync(Guid id, CustomerGroupCreateUpdateDto input)
    {
        return CustomerGroupAppService.UpdateAsync(id, input);
    }

    [HttpDelete]
    [Route("{id}")]
    public virtual Task DeleteAsync(Guid id)
    {
        return CustomerGroupAppService.DeleteAsync(id);
    }

}
