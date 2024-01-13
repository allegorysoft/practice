using Allegory.StockManagementApp.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace Allegory.StockManagementApp.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(StockManagementAppEntityFrameworkCoreModule),
    typeof(StockManagementAppApplicationContractsModule)
    )]
public class StockManagementAppDbMigratorModule : AbpModule
{
}
