using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Allegory.NgSampleApp.Data;

/* This is used if database provider does't define
 * INgSampleAppDbSchemaMigrator implementation.
 */
public class NullNgSampleAppDbSchemaMigrator : INgSampleAppDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
