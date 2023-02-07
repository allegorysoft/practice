using Localization.Resources.AbpUi;
using Allegory.NgSampleModule.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace Allegory.NgSampleModule;

[DependsOn(
    typeof(NgSampleModuleApplicationContractsModule),
    typeof(AbpAspNetCoreMvcModule))]
public class NgSampleModuleHttpApiModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddApplicationPartIfNotExists(typeof(NgSampleModuleHttpApiModule).Assembly);
        });
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<NgSampleModuleResource>()
                .AddBaseTypes(typeof(AbpUiResource));
        });
    }
}
