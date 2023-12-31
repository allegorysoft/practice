using Volo.Abp.AspNetCore.Components.WebAssembly.Theming;
using Volo.Abp.Modularity;

namespace Allegory.StockManagement.Blazor.WebAssembly;

[DependsOn(
    typeof(StockManagementBlazorModule),
    typeof(StockManagementHttpApiClientModule),
    typeof(AbpAspNetCoreComponentsWebAssemblyThemingModule)
    )]
public class StockManagementBlazorWebAssemblyModule : AbpModule
{

}
