using Allegory.StockManagement.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace Allegory.StockManagement.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(StockManagementEntityFrameworkCoreModule),
    typeof(StockManagementApplicationContractsModule)
    )]
public class StockManagementDbMigratorModule : AbpModule
{
}
