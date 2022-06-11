using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Allegory.SampleApp.Data;

/* This is used if database provider does't define
 * ISampleAppDbSchemaMigrator implementation.
 */
public class NullSampleAppDbSchemaMigrator : ISampleAppDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
