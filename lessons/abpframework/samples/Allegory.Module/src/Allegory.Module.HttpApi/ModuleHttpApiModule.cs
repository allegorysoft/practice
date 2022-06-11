using Localization.Resources.AbpUi;
using Allegory.Module.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace Allegory.Module;

[DependsOn(
    typeof(ModuleApplicationContractsModule),
    typeof(AbpAspNetCoreMvcModule))]
public class ModuleHttpApiModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddApplicationPartIfNotExists(typeof(ModuleHttpApiModule).Assembly);
        });
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<ModuleResource>()
                .AddBaseTypes(typeof(AbpUiResource));
        });
    }
}
