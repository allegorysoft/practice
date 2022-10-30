using System.Threading.Tasks;
using Volo.Abp.AuditLogging;
using Volo.Abp.Uow;

namespace Allegory.SampleApp.Example;

public class ExampleAppService : SampleAppAppService, IExampleAppService
{
    protected IExampleRepository ExampleRepository { get; }

    public ExampleAppService(IExampleRepository exampleRepository)
    {
        ExampleRepository = exampleRepository;
    }

    public virtual async Task GetExecutionPerformanceAsync()
    {
        await ExampleRepository.GetExecutionPerformanceAsync();
    }

    public virtual async Task ItThrowsDisposeExceptionAsync()
    {
        await ExampleRepository.ItThrowsDisposeExceptionAsync();

        var auditLogRepository = LazyServiceProvider.LazyGetRequiredService<IAuditLogRepository>();

        using (var uow = UnitOfWorkManager.Begin(true))
        {
            var resultUow = await auditLogRepository.GetListAsync();
        }

        var result = await auditLogRepository.GetListAsync();
    }

    public virtual async Task WithoutTransactionAsync()
    {
        await ExampleRepository.WithoutTransactionAsync();
    }

    public virtual async Task WithTransactionAsync()
    {
        await ExampleRepository.WithTransactionAsync();
    }
}
