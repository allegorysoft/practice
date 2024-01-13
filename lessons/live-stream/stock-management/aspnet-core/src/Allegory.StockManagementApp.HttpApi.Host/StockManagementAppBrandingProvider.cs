using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace Allegory.StockManagementApp;

[Dependency(ReplaceServices = true)]
public class StockManagementAppBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "StockManagementApp";
}
