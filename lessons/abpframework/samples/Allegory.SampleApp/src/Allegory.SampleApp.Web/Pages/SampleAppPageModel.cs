using Allegory.SampleApp.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Allegory.SampleApp.Web.Pages;

public abstract class SampleAppPageModel : AbpPageModel
{
    protected SampleAppPageModel()
    {
        LocalizationResourceType = typeof(SampleAppResource);
    }
}
