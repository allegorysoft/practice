using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace Allegory.NgSampleModule;

[DependsOn(
    typeof(AbpVirtualFileSystemModule)
    )]
public class NgSampleModuleInstallerModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<NgSampleModuleInstallerModule>();
        });
    }
}
