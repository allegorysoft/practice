using Allegory.StockManagement.Localization;
using Volo.Abp.Application.Services;

namespace Allegory.StockManagement;

public abstract class StockManagementAppService : ApplicationService
{
    protected StockManagementAppService()
    {
        LocalizationResource = typeof(StockManagementResource);
        ObjectMapperContext = typeof(StockManagementApplicationModule);
    }
}
