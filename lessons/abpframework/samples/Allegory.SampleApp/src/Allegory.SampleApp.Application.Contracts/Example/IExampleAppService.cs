using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Allegory.SampleApp.Example;

public interface IExampleAppService : IApplicationService
{
    Task GetExecutionPerformance();
    Task ItThrowsDisposeException();
    Task WithoutTransaction();
}
