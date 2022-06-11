using Allegory.SampleApp.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace Allegory.SampleApp.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(SampleAppEntityFrameworkCoreModule),
    typeof(SampleAppApplicationContractsModule)
    )]
public class SampleAppDbMigratorModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
    }
}
