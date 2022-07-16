using Allegory.SampleMongoApp.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Allegory.SampleMongoApp.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class SampleMongoAppController : AbpControllerBase
{
    protected SampleMongoAppController()
    {
        LocalizationResource = typeof(SampleMongoAppResource);
    }
}
