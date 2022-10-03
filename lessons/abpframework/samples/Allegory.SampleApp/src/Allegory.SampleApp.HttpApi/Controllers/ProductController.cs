using Allegory.SampleApp.Products;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Volo.Abp.Identity;
using Volo.Abp.Uow;

namespace Allegory.SampleApp.Controllers;

public class ProductController : SampleAppController, IProductAppService
{
    protected IProductAppService ProductAppService { get; }

    public ProductController(IProductAppService productAppService)
    {
        ProductAppService = productAppService;
    }

    [HttpGet("is-uow")]
    public bool IsUow() => ProductAppService.IsUow();

    [HttpGet("is-uow-async")]
    public Task<bool> IsUowAsync() => ProductAppService.IsUowAsync();

    [HttpGet("virtual-is-uow")]
    public bool VirtualIsUow() => ProductAppService.VirtualIsUow();

    [HttpGet("virtual-is-uow-async")]
    public Task<bool> VirtualIsUowAsync() => ProductAppService.VirtualIsUowAsync();

    [HttpPost("multiple-call")]
    public async Task MultipleCall()
    {
        ProductAppService.IsUow();
        await ProductAppService.IsUowAsync();
        ProductAppService.VirtualIsUow();
        await ProductAppService.VirtualIsUowAsync();

        var roleAppService = LazyServiceProvider.LazyGetRequiredService<IIdentityRoleAppService>();
        await roleAppService.CreateAsync(new IdentityRoleCreateDto
        {
            Name = "Role-1"
        });
        await roleAppService.CreateAsync(new IdentityRoleCreateDto
        {
            Name = "Role-2"
        });

        throw new Exception();
    }

    [UnitOfWork(false)]
    public async Task ProductManagerUow()
    {
        var productManager = LazyServiceProvider.LazyGetRequiredService<ProductManager>();

        await productManager.UowAttributeAsync();
    }
}
