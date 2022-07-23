using Allegory.NgSampleApp.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Allegory.NgSampleApp.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class NgSampleAppController : AbpControllerBase
{
    protected NgSampleAppController()
    {
        LocalizationResource = typeof(NgSampleAppResource);
    }
}
