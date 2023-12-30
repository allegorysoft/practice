using Localization.Resources.AbpUi;
using Allegory.StockManagement.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace Allegory.StockManagement;

[DependsOn(
    typeof(StockManagementApplicationContractsModule),
    typeof(AbpAspNetCoreMvcModule))]
public class StockManagementHttpApiModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddApplicationPartIfNotExists(typeof(StockManagementHttpApiModule).Assembly);
        });
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<StockManagementResource>()
                .AddBaseTypes(typeof(AbpUiResource));
        });
    }
}
