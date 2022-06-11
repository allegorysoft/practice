using Allegory.Module.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Allegory.Module.Web.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class ModulePageModel : AbpPageModel
{
    protected ModulePageModel()
    {
        LocalizationResourceType = typeof(ModuleResource);
        ObjectMapperContext = typeof(ModuleWebModule);
    }
}
