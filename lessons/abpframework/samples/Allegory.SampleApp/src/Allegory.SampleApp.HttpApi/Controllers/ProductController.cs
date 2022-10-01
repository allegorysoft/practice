using Allegory.SampleApp.Products;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

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

    [HttpGet("multiple-call")]
    public Task MultipleCall()
    {
        //Hepsi aynı UOW kullanır 
        ProductAppService.IsUow();
        ProductAppService.IsUowAsync();
        ProductAppService.VirtualIsUow();
        ProductAppService.VirtualIsUowAsync();

        return Task.CompletedTask;
    }
}
