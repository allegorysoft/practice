using Volo.Abp.Modularity;

namespace Allegory.StockManagementApp;

public abstract class StockManagementAppApplicationTestBase<TStartupModule> : StockManagementAppTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
