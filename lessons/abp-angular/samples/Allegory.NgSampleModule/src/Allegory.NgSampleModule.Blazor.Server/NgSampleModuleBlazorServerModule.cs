using Volo.Abp.AspNetCore.Components.Server.Theming;
using Volo.Abp.Modularity;

namespace Allegory.NgSampleModule.Blazor.Server;

[DependsOn(
    typeof(AbpAspNetCoreComponentsServerThemingModule),
    typeof(NgSampleModuleBlazorModule)
    )]
public class NgSampleModuleBlazorServerModule : AbpModule
{

}
