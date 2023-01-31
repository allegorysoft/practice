using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;
using Volo.Abp.MongoDB;

namespace Allegory.NgSampleModule.MongoDB;

[DependsOn(
    typeof(NgSampleModuleDomainModule),
    typeof(AbpMongoDbModule)
    )]
public class NgSampleModuleMongoDbModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddMongoDbContext<NgSampleModuleMongoDbContext>(options =>
        {
                /* Add custom repositories here. Example:
                 * options.AddRepository<Question, MongoQuestionRepository>();
                 */
        });
    }
}
