using Shouldly;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Modularity;
using Xunit;

namespace Allegory.Module.Customers;

public abstract class CustomerRepository_Tests<TStartupModule> : ModuleTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{
    private readonly ICustomerRepository _customerRepository;

    public CustomerRepository_Tests()
    {
        _customerRepository = GetRequiredService<ICustomerRepository>();
    }

    [Fact]
    public async Task Customer_Should_Be_Greater_Than_0()
    {
        var result = await _customerRepository.GetCountAsync();
        result.ShouldBeGreaterThan(0);
    }

    [Fact]
    public async Task Get_With_Details()
    {
        var result = await _customerRepository.GetPagedListAsync(0, 10, nameof(Customer.Id), true);

        result.Sum(y => y.ContactInformations.Count).ShouldBeGreaterThan(0);
    }
}
