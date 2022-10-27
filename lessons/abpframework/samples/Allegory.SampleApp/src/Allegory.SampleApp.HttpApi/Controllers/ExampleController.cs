using Allegory.SampleApp.Example;
using System.Threading.Tasks;

namespace Allegory.SampleApp.Controllers;

public class ExampleController : SampleAppController, IExampleAppService
{
    protected IExampleAppService ExampleAppService { get; }

    public ExampleController(IExampleAppService exampleAppService)
    {
        ExampleAppService = exampleAppService;
    }

    public virtual Task GetExecutionPerformance()
    {
        return ExampleAppService.GetExecutionPerformance();
    }
}
