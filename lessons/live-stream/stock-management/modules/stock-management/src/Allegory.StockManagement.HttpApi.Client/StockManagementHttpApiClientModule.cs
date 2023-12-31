using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace Allegory.StockManagement;

[DependsOn(
    typeof(StockManagementApplicationContractsModule),
    typeof(AbpHttpClientModule))]
public class StockManagementHttpApiClientModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddHttpClientProxies(
            typeof(StockManagementApplicationContractsModule).Assembly,
            StockManagementRemoteServiceConsts.RemoteServiceName
        );

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<StockManagementHttpApiClientModule>();
        });

    }
}
