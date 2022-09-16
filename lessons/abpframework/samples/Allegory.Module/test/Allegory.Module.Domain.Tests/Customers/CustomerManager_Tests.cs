using System.Linq;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Linq;
using Xunit;

namespace Allegory.Module.Customers;

public class CustomerManager_Tests : ModuleDomainTestBase
{
    private readonly ICustomerGroupRepository _customerGroupRepository;
    private readonly ICustomerRepository _customerRepository;
    private readonly CustomerManager _customerManager;

    public CustomerManager_Tests()
    {
        _customerGroupRepository = GetRequiredService<ICustomerGroupRepository>();
        _customerRepository = GetRequiredService<ICustomerRepository>();
        _customerManager = GetRequiredService<CustomerManager>();
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
        var result = await Assert.ThrowsAsync<BusinessException>(async () =>
         {
             await WithUnitOfWorkAsync(async () => await _customerManager.CreateCustomerGroupAsync("A Grubu"));
         });

        Assert.Equal(ModuleErrorCodes.CustomerGroupAlreadyExists, result.Code);
    }

    [Fact]
    public async Task Change_Customer_Group_Code()
    {
        CustomerGroup customerGroup = null;

        await WithUnitOfWorkAsync(async () =>
        {
            customerGroup = (await _customerGroupRepository.GetPagedListAsync(0, 1, nameof(CustomerGroup.Id))).FirstOrDefault();
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
            customer = (await _customerRepository.GetPagedListAsync(0, 1, nameof(Customer.Id))).FirstOrDefault();
            await _customerManager.SetCustomerGroupAsync(customer, "B Grubu");
            await _customerRepository.UpdateAsync(customer);
        });

        Assert.NotNull(customer.CustomerGroupId);
    }

    [Fact]
    public async Task Cannot_Set_Customer_To_A_Group_With_More_Than_10_Customers()
    {
        var result = await Assert.ThrowsAsync<BusinessException>(async () =>
        {
            await WithUnitOfWorkAsync(async () =>
            {
                var customer = (await _customerRepository.GetPagedListAsync(0, 20, nameof(Customer.Id))).FirstOrDefault(x => x.CustomerGroupId == null);
                await _customerManager.SetCustomerGroupAsync(customer, "A Grubu");
                await _customerRepository.UpdateAsync(customer);
            });
        });

        Assert.Equal(ModuleErrorCodes.CustomerCodeLimit, result.Code);
    }
}
