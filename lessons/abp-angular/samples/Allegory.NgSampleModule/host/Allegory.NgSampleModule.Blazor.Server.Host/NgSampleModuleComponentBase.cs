using Allegory.NgSampleModule.Localization;
using Volo.Abp.AspNetCore.Components;

namespace Allegory.NgSampleModule.Blazor.Server.Host;

public abstract class NgSampleModuleComponentBase : AbpComponentBase
{
    protected NgSampleModuleComponentBase()
    {
        LocalizationResource = typeof(NgSampleModuleResource);
    }
}
