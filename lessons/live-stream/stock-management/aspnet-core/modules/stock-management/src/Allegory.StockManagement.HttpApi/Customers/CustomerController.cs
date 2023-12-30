using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;

namespace Allegory.StockManagement.Customers;

[RemoteService(Name = StockManagementRemoteServiceConsts.RemoteServiceName)]
[Area(StockManagementRemoteServiceConsts.ModuleName)]
[ControllerName("Customer")]
[Route("api/stock-management/customers")]
public class CustomerController : StockManagementController, ICustomerAppService
{
    public ICustomerAppService CustomerAppService { get; }

    public CustomerController(ICustomerAppService customerAppService)
    {
        CustomerAppService = customerAppService;
    }

    [HttpGet]
    public Task<IReadOnlyList<CustomerDto>> GetListAsync()
    {
        return CustomerAppService.GetListAsync();
    }

    [HttpGet]
    [Route("{id:guid}")]
    public Task<CustomerDto> GetAsync(Guid id)
    {
        return CustomerAppService.GetAsync(id);
    }

    [HttpGet]
    [Route("{code}")]
    public Task<CustomerDto> GetByCodeAsync(string code)
    {
        return CustomerAppService.GetByCodeAsync(code);
    }

    [HttpPost]
    public Task<CustomerDto> CreateAsync(CustomerCreateDto input)
    {
        return CustomerAppService.CreateAsync(input);
    }
}