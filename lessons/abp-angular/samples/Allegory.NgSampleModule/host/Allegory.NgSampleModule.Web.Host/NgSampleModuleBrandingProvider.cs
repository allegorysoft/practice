using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace Allegory.NgSampleModule;

[Dependency(ReplaceServices = true)]
public class NgSampleModuleBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "NgSampleModule";
}
