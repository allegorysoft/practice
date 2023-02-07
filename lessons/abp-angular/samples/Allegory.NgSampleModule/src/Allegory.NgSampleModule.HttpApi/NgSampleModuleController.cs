using Allegory.NgSampleModule.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Allegory.NgSampleModule;

public abstract class NgSampleModuleController : AbpControllerBase
{
    protected NgSampleModuleController()
    {
        LocalizationResource = typeof(NgSampleModuleResource);
    }
}
