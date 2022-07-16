using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace Allegory.SampleMongoApp;

[Dependency(ReplaceServices = true)]
public class SampleMongoAppBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "SampleMongoApp";
}
