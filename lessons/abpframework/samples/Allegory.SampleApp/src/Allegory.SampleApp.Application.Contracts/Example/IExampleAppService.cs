using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Allegory.SampleApp.Example;

public interface IExampleAppService : IApplicationService
{
    Task GetExecutionPerformanceAsync();
    Task ItThrowsDisposeExceptionAsync();
    Task WithoutTransactionAsync();
    Task WithTransactionAsync();
    Task RunQueryAsync();
}
