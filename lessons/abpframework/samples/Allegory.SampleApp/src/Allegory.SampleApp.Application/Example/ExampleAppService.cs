namespace Allegory.SampleApp.Example;

public class ExampleAppService : SampleAppAppService, IExampleAppService
{
    protected IExampleRepository ExampleRepository { get; set; }

    public ExampleAppService(IExampleRepository exampleRepository)
    {
        ExampleRepository = exampleRepository;
    }
}
