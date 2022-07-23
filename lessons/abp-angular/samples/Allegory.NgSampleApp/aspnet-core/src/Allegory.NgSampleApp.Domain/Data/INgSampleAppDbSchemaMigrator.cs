using System.Threading.Tasks;

namespace Allegory.NgSampleApp.Data;

public interface INgSampleAppDbSchemaMigrator
{
    Task MigrateAsync();
}
