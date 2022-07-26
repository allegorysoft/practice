using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace Allegory.Module.Customers;

public class CustomerAppService_Tests : ModuleApplicationTestBase
{
    private readonly ICustomerAppService _customerAppService;

    public CustomerAppService_Tests()
    {
        _customerAppService = GetRequiredService<ICustomerAppService>();
    }

    [Fact]
    public async Task Should_List_Customers()
    {
        var customers = await _customerAppService.GetListAsync(new GetCustomerListDto()
        {
            SkipCount = 5,
            MaxResultCount = 5
        });

        customers.TotalCount.ShouldBeGreaterThan(5);
        customers.Items.Count.ShouldBe(5);
    }

    //test other methods
}
