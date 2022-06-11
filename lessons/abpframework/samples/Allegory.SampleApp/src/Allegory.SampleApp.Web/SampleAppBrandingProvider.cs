using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace Allegory.SampleApp.Web;

[Dependency(ReplaceServices = true)]
public class SampleAppBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "SampleApp";
}
