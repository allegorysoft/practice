using Volo.Abp.DependencyInjection;

namespace Allegory.SampleMongoApp;

//[Dependency(ServiceLifetime.Transient)]
public class SomeSpecificManager : ITransientDependency,
    ISomeSpecificManager, ISpecificManager, IManager, IcificManager,//Auto registered
    IMultiManager, //Manuel registered
    IOtherSomeSpecificManager, IOtherManager//Not registered
{

}
