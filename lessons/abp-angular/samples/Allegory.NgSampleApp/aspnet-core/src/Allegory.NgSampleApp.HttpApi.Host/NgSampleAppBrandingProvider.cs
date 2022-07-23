using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace Allegory.NgSampleApp;

[Dependency(ReplaceServices = true)]
public class NgSampleAppBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "NgSampleApp";
}
