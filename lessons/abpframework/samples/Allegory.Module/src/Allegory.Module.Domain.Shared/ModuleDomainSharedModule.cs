﻿using Allegory.Module.Localization;
using Volo.Abp.Localization;
using Volo.Abp.Localization.ExceptionHandling;
using Volo.Abp.Modularity;
using Volo.Abp.Validation;
using Volo.Abp.Validation.Localization;
using Volo.Abp.VirtualFileSystem;

namespace Allegory.Module;

[DependsOn(
    typeof(AbpValidationModule)
)]
public class ModuleDomainSharedModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<ModuleDomainSharedModule>();
        });

        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Add<ModuleResource>("en")
                .AddBaseTypes(typeof(AbpValidationResource))
                .AddVirtualJson("/Localization/Module");

            //options.DefaultResourceType = typeof(ModuleResource);
            //options.Resources
            //    .Get<ModuleResource>()
            //    .AddBaseTypes(typeof(DefaultResource))//Inherit From Other Resources
            //    .AddVirtualJson("/OtherLocalization/Module");//Extending Existing Resource
        });

        Configure<AbpExceptionLocalizationOptions>(options =>
        {
            options.MapCodeNamespace("Module", typeof(ModuleResource));
        });
    }
}
