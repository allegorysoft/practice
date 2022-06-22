using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Xunit;
using System.Linq;
using Volo.Abp.Linq;
using Shouldly;

namespace Allegory.Module.Customers;

public class CustomerManager_Tests : ModuleDomainTestBase
{
    private readonly IRepository<CustomerGroup, Guid> _customerGroupRepository;
    private readonly IRepository<Customer, Guid> _customerRepository;
    private readonly CustomerManager _customerManager;
    private readonly IAsyncQueryableExecuter _asyncExecuter;

    public CustomerManager_Tests()
    {
        _customerGroupRepository = GetRequiredService<IRepository<CustomerGroup, Guid>>();
        _customerRepository = GetRequiredService<IRepository<Customer, Guid>>();
        _customerManager = GetRequiredService<CustomerManager>();
        _asyncExecuter = GetRequiredService<IAsyncQueryableExecuter>();
    }

    [Fact]
    public async Task Create_A_Valid_Customer_Group_Code()
    {
        CustomerGroup customerGroup = null;
        await WithUnitOfWorkAsync(async () =>
        {
            customerGroup = await _customerManager.CreateCustomerGroupAsync("D Grubu");
            await _customerGroupRepository.InsertAsync(customerGroup);
        });

        Assert.NotNull(customerGroup);
    }

    [Fact]
    public async Task When_Try_To_Add_Existing_Customer_Group_Code_It_Must_Throw_Exception()
    {
        await Assert.ThrowsAsync<UserFriendlyException>(async () =>
        {
            await WithUnitOfWorkAsync(async () => await _customerManager.CreateCustomerGroupAsync("A Grubu"));
        });
    }

    [Fact]
    public async Task Change_Customer_Group_Code()
    {
        CustomerGroup customerGroup = null;

        await WithUnitOfWorkAsync(async () =>
        {
            customerGroup = await _customerGroupRepository.FirstOrDefaultAsync();
            await _customerManager.ChangeCustomerGroupCodeAsync(customerGroup, "D Grubu");
            await _customerGroupRepository.UpdateAsync(customerGroup);
        });

        Assert.Equal("D Grubu", customerGroup.Code);
    }

    [Fact]
    public async Task Set_Customer_To_A_Group()
    {
        Customer customer = null;

        await WithUnitOfWorkAsync(async () =>
        {
            customer = await _customerRepository.FirstOrDefaultAsync(c => c.CustomerGroupId == null);
            await _customerManager.SetCustomerGroupAsync(customer, "B Grubu");
            await _customerRepository.UpdateAsync(customer);
        });

        Assert.NotNull(customer.CustomerGroupId);
    }

    [Fact]
    public async Task Cannot_Set_Customer_To_A_Group_With_More_Than_10_Customers()
    {
        await Assert.ThrowsAsync<UserFriendlyException>(async () =>
        {
            await WithUnitOfWorkAsync(async () =>
            {
                var customer = await _customerRepository.FirstOrDefaultAsync(c => c.CustomerGroupId == null);
                await _customerManager.SetCustomerGroupAsync(customer, "A Grubu");
                await _customerRepository.UpdateAsync(customer);
            });
        });
    }

    [Fact]
    public async Task Join_Customers_To_Customer_Group()
    {
        await WithUnitOfWorkAsync(async () =>
        {
            var customerQueryable = await _customerRepository.GetQueryableAsync();
            var customerGroupQueryable = await _customerGroupRepository.GetQueryableAsync();

            var query = from customers in customerQueryable
                        join customerGroup in customerGroupQueryable on customers.CustomerGroupId equals customerGroup.Id into customerGroups
                        from customerGroup in customerGroups.DefaultIfEmpty()

                        select new
                        {
                            CustomerId = customers.Id,
                            CustomerName = customers.Name,
                            CustomerSurname = customers.Surname,
                            CustomerGroupCode = customerGroup.Code
                        };
            var list = await _asyncExecuter.ToListAsync(query);

            list.Count.ShouldBeGreaterThan(0);
        });

    }
}
