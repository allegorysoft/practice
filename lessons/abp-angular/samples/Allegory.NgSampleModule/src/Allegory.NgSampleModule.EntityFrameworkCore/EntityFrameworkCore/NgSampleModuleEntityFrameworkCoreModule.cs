using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Allegory.NgSampleModule.EntityFrameworkCore;

[DependsOn(
    typeof(NgSampleModuleDomainModule),
    typeof(AbpEntityFrameworkCoreModule)
)]
public class NgSampleModuleEntityFrameworkCoreModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAbpDbContext<NgSampleModuleDbContext>(options =>
        {
                /* Add custom repositories here. Example:
                 * options.AddRepository<Question, EfCoreQuestionRepository>();
                 */
        });
    }
}
