using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace Allegory.NgSampleModule.Blazor.Server.Host;

[Dependency(ReplaceServices = true)]
public class NgSampleModuleBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "NgSampleModule";
}
