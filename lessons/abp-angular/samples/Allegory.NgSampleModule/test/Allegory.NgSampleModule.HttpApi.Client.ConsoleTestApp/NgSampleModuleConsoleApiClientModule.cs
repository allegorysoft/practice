using Volo.Abp.Autofac;
using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace Allegory.NgSampleModule;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(NgSampleModuleHttpApiClientModule),
    typeof(AbpHttpClientIdentityModelModule)
    )]
public class NgSampleModuleConsoleApiClientModule : AbpModule
{

}
