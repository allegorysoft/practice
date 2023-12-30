using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;

namespace Allegory.StockManagement.Customers;

public class CustomerAppService : StockManagementAppService, ICustomerAppService
{
    public ICustomerRepository CustomerRepository { get; }
    public CustomerManager CustomerManager { get; }

    public CustomerAppService(
        ICustomerRepository customerRepository,
        CustomerManager customerManager)
    {
        CustomerRepository = customerRepository;
        CustomerManager = customerManager;
    }

    public async Task<IReadOnlyList<CustomerDto>> GetListAsync()
    {
        var customers = await CustomerRepository.GetListAsync();
        return ObjectMapper.Map<List<Customer>, List<CustomerDto>>(customers);
    }

    public async Task<CustomerDto> GetAsync(Guid id)
    {
        return ObjectMapper.Map<Customer, CustomerDto>(await CustomerRepository.GetAsync(id));
    }

    public async Task<CustomerDto> GetByCodeAsync(string code)
    {
        var customer = await CustomerRepository.FindByCodeAsync(code);

        if (customer == null)
        {
            throw new UserFriendlyException($"{code} kodlu müşteri bulunamadı.");
        }

        return ObjectMapper.Map<Customer, CustomerDto>(customer);
    }

    public async Task<CustomerDto> CreateAsync(CustomerCreateDto input)
    {
        var customer = await CustomerManager.CreateAsync(input.Code);
        customer.SetName(input.Name);

        await CustomerRepository.InsertAsync(customer);

        return ObjectMapper.Map<Customer, CustomerDto>(customer);
    }
}