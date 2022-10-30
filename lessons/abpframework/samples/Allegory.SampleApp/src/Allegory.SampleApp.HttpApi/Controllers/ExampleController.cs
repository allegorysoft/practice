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
    public virtual Task GetExecutionPerformance()
    {
        return ExampleAppService.GetExecutionPerformance();
    }

    [HttpGet("disposed-exception")]
    public Task ItThrowsDisposeException()
    {
        return ExampleAppService.ItThrowsDisposeException();
    }

    [HttpGet("without-transaction")]
    [UnitOfWork(true)]
    public Task WithoutTransaction()
    {
        return ExampleAppService.WithoutTransaction();
    }

    [HttpPost("with-transaction")]
    public Task WithTransaction()
    {
        return ExampleAppService.WithTransaction();
    }
}
