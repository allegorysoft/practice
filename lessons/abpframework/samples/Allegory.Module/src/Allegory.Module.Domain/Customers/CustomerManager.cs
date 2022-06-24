using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Allegory.Module.Customers;

public class CustomerManager : DomainService
{
    //TODO Add custom business exceptions

    protected ICustomerRepository CustomerRepository { get; }
    protected ICustomerGroupRepository CustomerGroupRepository { get; }

    public CustomerManager(
        ICustomerRepository customerRepository,
        ICustomerGroupRepository customerGroupRepository)
    {
        CustomerRepository = customerRepository;
        CustomerGroupRepository = customerGroupRepository;
    }

    public virtual async Task<CustomerGroup> CreateCustomerGroupAsync(string code, string description = default)
    {
        var existingCustomerGroup = await CustomerGroupRepository.FindByCodeAsync(code);
        if (existingCustomerGroup != null)
            throw new UserFriendlyException($"{code} kodlu müşteri grubu zaten kayıtlı");

        var customerGroup = new CustomerGroup(GuidGenerator.Create(), code, description: description);

        return customerGroup;
    }

    public virtual async Task ChangeCustomerGroupCodeAsync(CustomerGroup customerGroup, string newCode)
    {
        var existingCustomerGroup = await CustomerGroupRepository.FindByCodeAsync(newCode);
        if (existingCustomerGroup != null && existingCustomerGroup.Id != customerGroup.Id)
            throw new UserFriendlyException($"{newCode} kodlu müşteri grubu zaten kayıtlı");

        customerGroup.SetCode(newCode);
    }

    public virtual async Task SetCustomerGroupAsync(Customer customer, CustomerGroup customerGroup)
    {
        var customerGroupCount = await CustomerRepository.GetCountAsync(customerGroup.Id, customer.Id);

        if (customerGroupCount >= 10)
        {
            throw new UserFriendlyException($"{customerGroup.Code} kodlu müşteri grubuna 10'dan fazla müşteri bağlanamaz");
        }

        customer.CustomerGroupId = customerGroup.Id;
    }

    public virtual async Task<CustomerGroup> SetCustomerGroupAsync(Customer customer, string customerGroupCode)
    {
        var customerGroup = await CustomerGroupRepository.FindByCodeAsync(customerGroupCode);
        if (customerGroup == null)
            throw new UserFriendlyException($"{customerGroupCode} kodlu müşteri grubu bulunamadı");

        await SetCustomerGroupAsync(customer, customerGroup);

        return customerGroup;
    }
}
