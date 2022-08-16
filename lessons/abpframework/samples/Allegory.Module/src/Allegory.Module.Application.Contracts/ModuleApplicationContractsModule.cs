using Allegory.Module.Authorization;
using Volo.Abp.Application;
using Volo.Abp.Authorization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Modularity;

namespace Allegory.Module;

[DependsOn(
    typeof(ModuleDomainSharedModule),
    typeof(AbpDddApplicationContractsModule),
    typeof(AbpAuthorizationModule)
    )]
public class ModuleApplicationContractsModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpPermissionOptions>(options =>
        {
            options.ValueProviders.Add<NameCheckPermissionValueProvider>();
        });
    }
}
