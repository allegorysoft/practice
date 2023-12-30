using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace Allegory.StockManagement;

[DependsOn(
    typeof(AbpVirtualFileSystemModule)
    )]
public class StockManagementInstallerModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<StockManagementInstallerModule>();
        });
    }
}
