using Allegory.NgSampleApp.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace Allegory.NgSampleApp.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(NgSampleAppEntityFrameworkCoreModule),
    typeof(NgSampleAppApplicationContractsModule)
    )]
public class NgSampleAppDbMigratorModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
    }
}
