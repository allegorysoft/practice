using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace Allegory.NgSampleModule.MongoDB;

[ConnectionStringName(NgSampleModuleDbProperties.ConnectionStringName)]
public class NgSampleModuleMongoDbContext : AbpMongoDbContext, INgSampleModuleMongoDbContext
{
    /* Add mongo collections here. Example:
     * public IMongoCollection<Question> Questions => Collection<Question>();
     */

    protected override void CreateModel(IMongoModelBuilder modelBuilder)
    {
        base.CreateModel(modelBuilder);

        modelBuilder.ConfigureNgSampleModule();
    }
}
