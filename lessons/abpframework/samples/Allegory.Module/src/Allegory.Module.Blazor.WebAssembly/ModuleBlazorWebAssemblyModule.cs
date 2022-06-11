using Volo.Abp.AspNetCore.Components.WebAssembly.Theming;
using Volo.Abp.Modularity;

namespace Allegory.Module.Blazor.WebAssembly;

[DependsOn(
    typeof(ModuleBlazorModule),
    typeof(ModuleHttpApiClientModule),
    typeof(AbpAspNetCoreComponentsWebAssemblyThemingModule)
    )]
public class ModuleBlazorWebAssemblyModule : AbpModule
{

}
