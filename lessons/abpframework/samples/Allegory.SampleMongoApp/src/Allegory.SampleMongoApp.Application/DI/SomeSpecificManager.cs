using Volo.Abp.DependencyInjection;

namespace Allegory.SampleMongoApp.DI;

//[Dependency(ServiceLifetime.Scoped)]
public class SomeSpecificManager : ITransientDependency,
    ISomeSpecificManager, ISpecificManager, IManager, IcificManager,//Auto registered
    IMultiManager, //Manuel registered
    IOtherSomeSpecificManager, IOtherManager//Not registered
{

}
