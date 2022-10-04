using Shouldly;
using System;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Identity;
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

    [Fact]
    public async Task Repository_Test()
    {
        var roleRepository = GetRequiredService<IRepository<IdentityRole, Guid>>();

        var result = await roleRepository.GetListAsync();

        await Assert.ThrowsAnyAsync<Exception>(async () =>
        {
            await roleRepository.AnyAsync(x => x.Name.StartsWith("Role-"));
        });
        await WithUnitOfWorkAsync(async () =>
        {
            await roleRepository.AnyAsync(x => x.Name.StartsWith("Role-"));
        });
    }
}
