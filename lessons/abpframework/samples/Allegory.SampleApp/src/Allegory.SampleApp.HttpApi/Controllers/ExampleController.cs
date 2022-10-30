using Allegory.SampleApp.Example;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Volo.Abp.Uow;

namespace Allegory.SampleApp.Controllers;

[Route("api/app/example")]
public class ExampleController : SampleAppController, IExampleAppService
{
    protected IExampleAppService ExampleAppService { get; }

    public ExampleController(IExampleAppService exampleAppService)
    {
        ExampleAppService = exampleAppService;
    }

    [HttpGet]
    public virtual Task GetExecutionPerformanceAsync()
    {
        return ExampleAppService.GetExecutionPerformanceAsync();
    }

    [HttpGet("disposed-exception")]
    public virtual Task ItThrowsDisposeExceptionAsync()
    {
        return ExampleAppService.ItThrowsDisposeExceptionAsync();
    }

    [HttpGet("without-transaction")]
    [UnitOfWork(true)]
    public virtual Task WithoutTransactionAsync()
    {
        return ExampleAppService.WithoutTransactionAsync();
    }

    [HttpPost("with-transaction")]
    public virtual Task WithTransactionAsync()
    {
        return ExampleAppService.WithTransactionAsync();
    }

    [HttpGet("run-query")]
    public virtual Task RunQueryAsync()
    {
        return ExampleAppService.RunQueryAsync();
    }
}
