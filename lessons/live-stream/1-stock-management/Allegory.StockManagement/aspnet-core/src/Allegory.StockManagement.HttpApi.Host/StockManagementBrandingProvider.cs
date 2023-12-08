using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace Allegory.StockManagement;

[Dependency(ReplaceServices = true)]
public class StockManagementBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "StockManagement";
}
