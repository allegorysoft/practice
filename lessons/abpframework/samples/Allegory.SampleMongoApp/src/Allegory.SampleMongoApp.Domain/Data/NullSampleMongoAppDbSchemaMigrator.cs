using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Allegory.SampleMongoApp.Data;

/* This is used if database provider does't define
 * ISampleMongoAppDbSchemaMigrator implementation.
 */
public class NullSampleMongoAppDbSchemaMigrator : ISampleMongoAppDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
