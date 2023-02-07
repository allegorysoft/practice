using Allegory.NgSampleModule.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Allegory.NgSampleModule.Web.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class NgSampleModulePageModel : AbpPageModel
{
    protected NgSampleModulePageModel()
    {
        LocalizationResourceType = typeof(NgSampleModuleResource);
        ObjectMapperContext = typeof(NgSampleModuleWebModule);
    }
}
