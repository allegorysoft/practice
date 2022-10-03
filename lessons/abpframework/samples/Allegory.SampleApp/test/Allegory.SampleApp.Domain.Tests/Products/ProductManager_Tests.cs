using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace Allegory.SampleApp.Products;

public class ProductManager_Tests : SampleAppDomainTestBase
{
    private readonly ProductManager _productManager;

    public ProductManager_Tests()
	{
        _productManager = GetRequiredService<ProductManager>();
    }

    [Fact]
    public async Task Is_Unit_of_Work()
    {
        _productManager.IsUow().ShouldBe(false);
        _productManager.VirtualIsUow().ShouldBe(false);
        (await _productManager.IsUowAsync()).ShouldBe(false);
        (await _productManager.VirtualIsUowAsync()).ShouldBe(false);
        (await _productManager.UowAttributeAsync()).ShouldBe(true);

        await WithUnitOfWorkAsync(async () =>
        {
            _productManager.IsUow().ShouldBe(true);
            _productManager.VirtualIsUow().ShouldBe(true);
            (await _productManager.IsUowAsync()).ShouldBe(true);
            (await _productManager.VirtualIsUowAsync()).ShouldBe(true);
            (await _productManager.UowAttributeAsync()).ShouldBe(true);
        });
    }
}
