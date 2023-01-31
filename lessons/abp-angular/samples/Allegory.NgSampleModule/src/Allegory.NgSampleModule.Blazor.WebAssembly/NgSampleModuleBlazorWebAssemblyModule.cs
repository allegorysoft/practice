using Volo.Abp.AspNetCore.Components.WebAssembly.Theming;
using Volo.Abp.Modularity;

namespace Allegory.NgSampleModule.Blazor.WebAssembly;

[DependsOn(
    typeof(NgSampleModuleBlazorModule),
    typeof(NgSampleModuleHttpApiClientModule),
    typeof(AbpAspNetCoreComponentsWebAssemblyThemingModule)
    )]
public class NgSampleModuleBlazorWebAssemblyModule : AbpModule
{

}
