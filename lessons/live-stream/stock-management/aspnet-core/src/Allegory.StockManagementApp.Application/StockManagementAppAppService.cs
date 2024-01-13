using System;
using System.Collections.Generic;
using System.Text;
using Allegory.StockManagementApp.Localization;
using Volo.Abp.Application.Services;

namespace Allegory.StockManagementApp;

/* Inherit your application services from this class.
 */
public abstract class StockManagementAppAppService : ApplicationService
{
    protected StockManagementAppAppService()
    {
        LocalizationResource = typeof(StockManagementAppResource);
    }
}
