using Volo.Abp.Modularity;

namespace Allegory.StockManagement;

/* Inherit from this class for your application layer tests.
 * See SampleAppService_Tests for example.
 */
public abstract class StockManagementApplicationTestBase<TStartupModule> : StockManagementTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
