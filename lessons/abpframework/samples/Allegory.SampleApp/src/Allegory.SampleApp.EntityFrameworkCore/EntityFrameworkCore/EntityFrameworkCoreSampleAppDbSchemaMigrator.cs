using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Allegory.SampleApp.Data;
using Volo.Abp.DependencyInjection;

namespace Allegory.SampleApp.EntityFrameworkCore;

public class EntityFrameworkCoreSampleAppDbSchemaMigrator
    : ISampleAppDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreSampleAppDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the SampleAppDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<SampleAppDbContext>()
            .Database
            .MigrateAsync();
    }
}
