using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace Allegory.StockManagement;

[Dependency(ReplaceServices = true)]
public class StockManagementBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "StockManagement";
}
