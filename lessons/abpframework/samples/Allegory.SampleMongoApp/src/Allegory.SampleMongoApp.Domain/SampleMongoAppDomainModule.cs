using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Allegory.SampleMongoApp.MultiTenancy;
using Allegory.SampleMongoApp.OptionsPattern;
using Microsoft.Extensions.Configuration;
using Volo.Abp.AuditLogging;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Emailing;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.IdentityServer;
using Volo.Abp.Modularity;
using Volo.Abp.MultiTenancy;
using Volo.Abp.PermissionManagement.Identity;
using Volo.Abp.PermissionManagement.IdentityServer;
using Volo.Abp.SettingManagement;
using Volo.Abp.TenantManagement;

namespace Allegory.SampleMongoApp;

[DependsOn(
    typeof(SampleMongoAppDomainSharedModule),
    typeof(AbpAuditLoggingDomainModule),
    typeof(AbpBackgroundJobsDomainModule),
    typeof(AbpFeatureManagementDomainModule),
    typeof(AbpIdentityDomainModule),
    typeof(AbpPermissionManagementDomainIdentityModule),
    typeof(AbpIdentityServerDomainModule),
    typeof(AbpPermissionManagementDomainIdentityServerModule),
    typeof(AbpSettingManagementDomainModule),
    typeof(AbpTenantManagementDomainModule),
    typeof(AbpEmailingModule)
)]
public class SampleMongoAppDomainModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PreConfigure<SamplePreOptions>(options =>
        {
            options.IntegrationService = context.Services.GetConfiguration().GetValue<string>("SamplePre:IntegrationService");
            options.DoOtherThings = true;
        });
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<SampleOptions>(context.Services.GetConfiguration().GetSection(SampleOptions.Position));
        /*
        Configure<SampleOptions>(c =>
        {
            c.Username = "ahmet";
            c.Password = "edFg4Ac";
        });
        */

        var option = context.Services.ExecutePreConfiguredActions<SamplePreOptions>();
        context.Services.AddTransient(typeof(IIntegrationService), option.GetIntegrationService());
        if (option.DoOtherThings)
        {
            //...
        }

        Configure<AbpMultiTenancyOptions>(options => { options.IsEnabled = MultiTenancyConsts.IsEnabled; });

#if DEBUG
        context.Services.Replace(ServiceDescriptor.Singleton<IEmailSender, NullEmailSender>());
#endif
    }
}