using Volo.Abp.Autofac;
using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace Allegory.Module;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(ModuleHttpApiClientModule),
    typeof(AbpHttpClientIdentityModelModule)
    )]
public class ModuleConsoleApiClientModule : AbpModule
{

}
