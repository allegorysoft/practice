using Volo.Abp.AspNetCore.Components.Server.Theming;
using Volo.Abp.Modularity;

namespace Allegory.StockManagement.Blazor.Server;

[DependsOn(
    typeof(AbpAspNetCoreComponentsServerThemingModule),
    typeof(StockManagementBlazorModule)
    )]
public class StockManagementBlazorServerModule : AbpModule
{

}
