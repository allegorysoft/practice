using Volo.Abp.Ui.Branding;

namespace Allegory.Module.Blazor.Host;

public class ModuleHostBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "Module";
}
