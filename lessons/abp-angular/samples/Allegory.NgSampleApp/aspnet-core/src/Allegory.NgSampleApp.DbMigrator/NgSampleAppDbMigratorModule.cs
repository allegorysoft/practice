using Allegory.NgSampleApp.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace Allegory.NgSampleApp.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(NgSampleAppEntityFrameworkCoreModule),
    typeof(NgSampleAppApplicationContractsModule)
    )]
public class NgSampleAppDbMigratorModule : AbpModule
{

}
