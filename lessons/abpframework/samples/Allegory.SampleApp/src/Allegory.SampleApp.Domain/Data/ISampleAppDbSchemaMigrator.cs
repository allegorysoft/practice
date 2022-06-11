using System.Threading.Tasks;

namespace Allegory.SampleApp.Data;

public interface ISampleAppDbSchemaMigrator
{
    Task MigrateAsync();
}
