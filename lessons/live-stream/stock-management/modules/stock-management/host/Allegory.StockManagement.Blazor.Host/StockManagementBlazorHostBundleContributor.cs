using Volo.Abp.Bundling;

namespace Allegory.StockManagement.Blazor.Host;

public class StockManagementBlazorHostBundleContributor : IBundleContributor
{
    public void AddScripts(BundleContext context)
    {

    }

    public void AddStyles(BundleContext context)
    {
        context.Add("main.css", true);
    }
}
