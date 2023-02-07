using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace Allegory.NgSampleModule;

[DependsOn(
    typeof(NgSampleModuleApplicationContractsModule),
    typeof(AbpHttpClientModule))]
public class NgSampleModuleHttpApiClientModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddHttpClientProxies(
            typeof(NgSampleModuleApplicationContractsModule).Assembly,
            NgSampleModuleRemoteServiceConsts.RemoteServiceName
        );

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<NgSampleModuleHttpApiClientModule>();
        });

    }
}
