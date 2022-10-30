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

    public virtual async Task GetExecutionPerformance()
    {
        await ExampleRepository.GetExecutionPerformance();
    }

    public virtual async Task ItThrowsDisposeException()
    {
        await ExampleRepository.ItThrowsDisposeException();

        var auditLogRepository = LazyServiceProvider.LazyGetRequiredService<IAuditLogRepository>();

        using (var uow = UnitOfWorkManager.Begin(true))
        {
            var resultUow = await auditLogRepository.GetListAsync();
        }

        var result = await auditLogRepository.GetListAsync();
    }

    public virtual async Task WithoutTransaction()
    {
        await ExampleRepository.WithoutTransaction();
    }

    public virtual async Task WithTransaction()
    {
        await ExampleRepository.WithTransaction();
    }
}
