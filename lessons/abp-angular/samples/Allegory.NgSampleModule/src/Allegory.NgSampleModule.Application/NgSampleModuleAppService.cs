using Allegory.NgSampleModule.Localization;
using Volo.Abp.Application.Services;

namespace Allegory.NgSampleModule;

public abstract class NgSampleModuleAppService : ApplicationService
{
    protected NgSampleModuleAppService()
    {
        LocalizationResource = typeof(NgSampleModuleResource);
        ObjectMapperContext = typeof(NgSampleModuleApplicationModule);
    }
}
