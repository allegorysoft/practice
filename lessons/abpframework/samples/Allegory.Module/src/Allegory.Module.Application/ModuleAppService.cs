using Allegory.Module.Localization;
using Volo.Abp.Application.Services;

namespace Allegory.Module;

public abstract class ModuleAppService : ApplicationService
{
    protected ModuleAppService()
    {
        LocalizationResource = typeof(ModuleResource);
        ObjectMapperContext = typeof(ModuleApplicationModule);
    }
}
