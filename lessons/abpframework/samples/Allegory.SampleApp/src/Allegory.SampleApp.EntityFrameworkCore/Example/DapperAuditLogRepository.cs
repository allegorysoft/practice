using Dapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.AuditLogging;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Allegory.SampleApp.Example;

public class DapperAuditLogRepository : EfCoreRepository<IAuditLoggingDbContext, AuditLog, Guid>, IDapperAuditLogRepository
{
    protected ILogger<DapperAuditLogRepository> Logger { get; }

    public DapperAuditLogRepository(
        IDbContextProvider<IAuditLoggingDbContext> dbContextProvider,
        ILogger<DapperAuditLogRepository> logger) : base(dbContextProvider)
    {
        Logger = logger;
    }

    public virtual async Task RunQueryAsync(CancellationToken cancellationToken = default)
    {
        var connection = (await GetDbContextAsync()).Database.GetDbConnection();
        var transaction = (await GetDbContextAsync()).Database.CurrentTransaction?.GetDbTransaction();

        var commandDefinition = new CommandDefinition(@"SELECT SLEEP(10) UNION ALL SELECT 'Run query';",
            transaction: transaction,
            cancellationToken: GetCancellationToken(cancellationToken));

        var result = await connection.QueryAsync(commandDefinition);
        Logger.LogInformation("First query done");

        var result2 = await connection.QueryAsync(commandDefinition);
        Logger.LogInformation("Second query done");
    }
}
