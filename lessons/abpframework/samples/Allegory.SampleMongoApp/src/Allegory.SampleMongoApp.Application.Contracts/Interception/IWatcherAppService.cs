using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Allegory.SampleMongoApp.Interception;

public interface IWatcherAppService : IApplicationService
{
    Task<int> Method1Async();
    Task<int> Method2Async();
    Task Method3Async();
    Task Method4Async();
}