using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Allegory.NgSampleApp.Data;
using Volo.Abp.DependencyInjection;

namespace Allegory.NgSampleApp.EntityFrameworkCore;

public class EntityFrameworkCoreNgSampleAppDbSchemaMigrator
    : INgSampleAppDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreNgSampleAppDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the NgSampleAppDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<NgSampleAppDbContext>()
            .Database
            .MigrateAsync();
    }
}
