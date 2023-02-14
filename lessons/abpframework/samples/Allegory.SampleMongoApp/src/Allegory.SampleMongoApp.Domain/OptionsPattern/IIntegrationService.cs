using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Allegory.SampleMongoApp.OptionsPattern;

public interface IIntegrationService : ITransientDependency
{
    Task DoAsync();
}