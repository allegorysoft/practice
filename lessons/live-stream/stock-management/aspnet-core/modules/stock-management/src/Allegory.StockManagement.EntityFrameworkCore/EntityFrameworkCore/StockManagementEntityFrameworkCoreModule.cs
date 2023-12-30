using Allegory.StockManagement.Customers;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Allegory.StockManagement.EntityFrameworkCore;

[DependsOn(
    typeof(StockManagementDomainModule),
    typeof(AbpEntityFrameworkCoreModule)
)]
public class StockManagementEntityFrameworkCoreModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAbpDbContext<StockManagementDbContext>(options =>
        {
            options.AddRepository<Customer, EfCoreCustomerRepository>();
        });
    }
}