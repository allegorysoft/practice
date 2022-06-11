using Allegory.Module.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Allegory.Module;

public abstract class ModuleController : AbpControllerBase
{
    protected ModuleController()
    {
        LocalizationResource = typeof(ModuleResource);
    }
}
