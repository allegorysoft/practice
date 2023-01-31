using Volo.Abp;
using Volo.Abp.MongoDB;

namespace Allegory.NgSampleModule.MongoDB;

public static class NgSampleModuleMongoDbContextExtensions
{
    public static void ConfigureNgSampleModule(
        this IMongoModelBuilder builder)
    {
        Check.NotNull(builder, nameof(builder));
    }
}
