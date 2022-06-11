using Volo.Abp.Bundling;

namespace Allegory.Module.Blazor.Host;

public class ModuleBlazorHostBundleContributor : IBundleContributor
{
    public void AddScripts(BundleContext context)
    {

    }

    public void AddStyles(BundleContext context)
    {
        context.Add("main.css", true);
    }
}
