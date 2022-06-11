using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace Allegory.Module.Blazor.Server.Host;

[Dependency(ReplaceServices = true)]
public class ModuleBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "Module";
}
