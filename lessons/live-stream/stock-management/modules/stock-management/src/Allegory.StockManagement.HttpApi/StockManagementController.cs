using Allegory.StockManagement.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Allegory.StockManagement;

public abstract class StockManagementController : AbpControllerBase
{
    protected StockManagementController()
    {
        LocalizationResource = typeof(StockManagementResource);
    }
}
