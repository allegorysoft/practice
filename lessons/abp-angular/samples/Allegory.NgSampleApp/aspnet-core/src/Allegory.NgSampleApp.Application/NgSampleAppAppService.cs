using System;
using System.Collections.Generic;
using System.Text;
using Allegory.NgSampleApp.Localization;
using Volo.Abp.Application.Services;

namespace Allegory.NgSampleApp;

/* Inherit your application services from this class.
 */
public abstract class NgSampleAppAppService : ApplicationService
{
    protected NgSampleAppAppService()
    {
        LocalizationResource = typeof(NgSampleAppResource);
    }
}
