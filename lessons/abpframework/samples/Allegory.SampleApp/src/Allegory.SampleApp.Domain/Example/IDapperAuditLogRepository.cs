using System;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.AuditLogging;
using Volo.Abp.Domain.Repositories;

namespace Allegory.SampleApp.Example;

public interface IDapperAuditLogRepository : IRepository<AuditLog, Guid>
{
    Task RunQueryAsync(CancellationToken cancellationToken = default);
}
