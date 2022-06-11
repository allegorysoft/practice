using Allegory.SampleApp.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Allegory.SampleApp.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class SampleAppController : AbpControllerBase
{
    protected SampleAppController()
    {
        LocalizationResource = typeof(SampleAppResource);
    }
}
