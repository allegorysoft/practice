using Microsoft.Extensions.DependencyInjection;
using Allegory.NgSampleModule.Blazor.Menus;
using Volo.Abp.AspNetCore.Components.Web.Theming;
using Volo.Abp.AspNetCore.Components.Web.Theming.Routing;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.UI.Navigation;

namespace Allegory.NgSampleModule.Blazor;

[DependsOn(
    typeof(NgSampleModuleApplicationContractsModule),
    typeof(AbpAspNetCoreComponentsWebThemingModule),
    typeof(AbpAutoMapperModule)
    )]
public class NgSampleModuleBlazorModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAutoMapperObjectMapper<NgSampleModuleBlazorModule>();

        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddProfile<NgSampleModuleBlazorAutoMapperProfile>(validate: true);
        });

        Configure<AbpNavigationOptions>(options =>
        {
            options.MenuContributors.Add(new NgSampleModuleMenuContributor());
        });

        Configure<AbpRouterOptions>(options =>
        {
            options.AdditionalAssemblies.Add(typeof(NgSampleModuleBlazorModule).Assembly);
        });
    }
}
