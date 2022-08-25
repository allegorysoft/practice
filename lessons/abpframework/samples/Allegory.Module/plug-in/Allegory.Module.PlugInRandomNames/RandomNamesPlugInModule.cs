using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace Allegory.Module.PlugInRandomNames;

[DependsOn(typeof(AbpVirtualFileSystemModule))]
public class RandomNamesPlugInModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<RandomNamesPlugInModule>();
        });

        context.Services.AddHostedService<RuntimeRegisterer>();
    }
}