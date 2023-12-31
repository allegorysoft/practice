using Allegory.StockManagement.Localization;
using Volo.Abp.AspNetCore.Components;

namespace Allegory.StockManagement.Blazor.Server.Host;

public abstract class StockManagementComponentBase : AbpComponentBase
{
    protected StockManagementComponentBase()
    {
        LocalizationResource = typeof(StockManagementResource);
    }
}
