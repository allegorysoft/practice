using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace Allegory.SampleApp;

[Dependency(ReplaceServices = true)]
public class SampleAppBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "SampleApp";
}
