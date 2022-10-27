using System.Threading.Tasks;

namespace Allegory.SampleApp.Example;

public class ExampleAppService : SampleAppAppService, IExampleAppService
{
    protected IExampleRepository ExampleRepository { get; set; }

    public ExampleAppService(IExampleRepository exampleRepository)
    {
        ExampleRepository = exampleRepository;
    }

    public async Task GetExecutionPerformance()
    {
        await ExampleRepository.GetExecutionPerformance();
    }
}
