using Allegory.StockManagement.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Allegory.StockManagement.Pages;

public abstract class StockManagementPageModel : AbpPageModel
{
    protected StockManagementPageModel()
    {
        LocalizationResourceType = typeof(StockManagementResource);
    }
}
