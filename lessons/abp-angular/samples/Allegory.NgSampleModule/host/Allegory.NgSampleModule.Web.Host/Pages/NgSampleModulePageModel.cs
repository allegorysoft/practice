using Allegory.NgSampleModule.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Allegory.NgSampleModule.Pages;

public abstract class NgSampleModulePageModel : AbpPageModel
{
    protected NgSampleModulePageModel()
    {
        LocalizationResourceType = typeof(NgSampleModuleResource);
    }
}
