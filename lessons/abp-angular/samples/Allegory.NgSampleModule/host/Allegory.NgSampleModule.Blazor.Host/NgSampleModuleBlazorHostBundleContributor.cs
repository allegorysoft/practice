using Volo.Abp.Bundling;

namespace Allegory.NgSampleModule.Blazor.Host;

public class NgSampleModuleBlazorHostBundleContributor : IBundleContributor
{
    public void AddScripts(BundleContext context)
    {

    }

    public void AddStyles(BundleContext context)
    {
        context.Add("main.css", true);
    }
}
