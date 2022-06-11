using Allegory.Module.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Allegory.Module.Pages;

public abstract class ModulePageModel : AbpPageModel
{
    protected ModulePageModel()
    {
        LocalizationResourceType = typeof(ModuleResource);
    }
}
