using Shouldly;
using System;
using System.Threading.Tasks;
using Volo.Abp.Identity;
using Xunit;

namespace Allegory.SampleApp.Products;

public class ProductAppService_Tests : SampleAppApplicationTestBase
{
    private readonly ProductAppService _productAppService;
    private readonly IProductAppService _productAppServiceInterface;

    public ProductAppService_Tests()
    {
        _productAppService = GetRequiredService<ProductAppService>();
        _productAppServiceInterface = GetRequiredService<IProductAppService>();
    }

    [Fact]
    public async Task Is_Unit_of_Work()
    {
        _productAppService.IsUow().ShouldBe(false);
        _productAppService.VirtualIsUow().ShouldBe(true);
        (await _productAppService.IsUowAsync()).ShouldBe(false);
        (await _productAppService.VirtualIsUowAsync()).ShouldBe(true);

        _productAppServiceInterface.IsUow().ShouldBe(true);
        _productAppServiceInterface.VirtualIsUow().ShouldBe(true);
        (await _productAppServiceInterface.IsUowAsync()).ShouldBe(true);
        (await _productAppServiceInterface.VirtualIsUowAsync()).ShouldBe(true);
    }

    [Fact]
    public async Task Multiple_Call()
    {
        var roleAppService = GetRequiredService<IIdentityRoleAppService>();

        await Assert.ThrowsAsync<Exception>(async () =>
        {
            await roleAppService.CreateAsync(new IdentityRoleCreateDto
            {
                Name = "Role-1"
            });
            await roleAppService.CreateAsync(new IdentityRoleCreateDto
            {
                Name = "Role-2"
            });

            throw new Exception();
        });

        var result = await roleAppService.GetAllListAsync();
    }
}
