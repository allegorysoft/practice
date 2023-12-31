using Volo.Abp.Modularity;

namespace Allegory.StockManagement;

/* Inherit from this class for your domain layer tests.
 * See SampleManager_Tests for example.
 */
public abstract class StockManagementDomainTestBase<TStartupModule> : StockManagementTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
