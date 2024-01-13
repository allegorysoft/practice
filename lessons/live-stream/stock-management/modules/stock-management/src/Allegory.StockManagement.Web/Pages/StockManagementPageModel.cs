using Allegory.StockManagement.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Allegory.StockManagement.Web.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class StockManagementPageModel : AbpPageModel
{
    protected StockManagementPageModel()
    {
        LocalizationResourceType = typeof(StockManagementResource);
        ObjectMapperContext = typeof(StockManagementWebModule);
    }
}
