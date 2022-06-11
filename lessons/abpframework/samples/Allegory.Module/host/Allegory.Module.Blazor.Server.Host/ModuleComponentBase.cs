using Allegory.Module.Localization;
using Volo.Abp.AspNetCore.Components;

namespace Allegory.Module.Blazor.Server.Host;

public abstract class ModuleComponentBase : AbpComponentBase
{
    protected ModuleComponentBase()
    {
        LocalizationResource = typeof(ModuleResource);
    }
}
