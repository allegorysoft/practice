using System.Threading.Tasks;

namespace Allegory.SampleMongoApp.Data;

public interface ISampleMongoAppDbSchemaMigrator
{
    Task MigrateAsync();
}
