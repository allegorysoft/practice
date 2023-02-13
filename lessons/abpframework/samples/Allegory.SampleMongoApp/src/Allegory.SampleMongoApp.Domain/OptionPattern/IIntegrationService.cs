using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Allegory.SampleMongoApp.OptionPattern;

public interface IIntegrationService : ITransientDependency
{
    Task DoAsync();
}