using Volo.Abp.Autofac;
using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace Allegory.StockManagement;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(StockManagementHttpApiClientModule),
    typeof(AbpHttpClientIdentityModelModule)
    )]
public class StockManagementConsoleApiClientModule : AbpModule
{

}
