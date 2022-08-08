namespace Allegory.SampleMongoApp;

public class SampleAppService : SampleMongoAppAppService
{
    public IManager Manager { get; set; }
    protected ISomeSpecificManager SomeSpecificManager { get; }
    public ISpecificManager SpecificManager
    {
        get
        {
            return LazyServiceProvider.LazyGetRequiredService<ISpecificManager>();
        }
    }

    public SampleAppService(ISomeSpecificManager someSpecificManager)
    {
        SomeSpecificManager = someSpecificManager;
    }
}
