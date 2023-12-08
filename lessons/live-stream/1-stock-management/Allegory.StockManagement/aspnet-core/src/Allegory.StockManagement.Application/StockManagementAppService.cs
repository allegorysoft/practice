using System;
using System.Collections.Generic;
using System.Text;
using Allegory.StockManagement.Localization;
using Volo.Abp.Application.Services;

namespace Allegory.StockManagement;

/* Inherit your application services from this class.
 */
public abstract class StockManagementAppService : ApplicationService
{
    protected StockManagementAppService()
    {
        LocalizationResource = typeof(StockManagementResource);
    }
}
