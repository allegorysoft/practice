using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace Allegory.NgSampleModule.MongoDB;

[ConnectionStringName(NgSampleModuleDbProperties.ConnectionStringName)]
public interface INgSampleModuleMongoDbContext : IAbpMongoDbContext
{
    /* Define mongo collections here. Example:
     * IMongoCollection<Question> Questions { get; }
     */
}
