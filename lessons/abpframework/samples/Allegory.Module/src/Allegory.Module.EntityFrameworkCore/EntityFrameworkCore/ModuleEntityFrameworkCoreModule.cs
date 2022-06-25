using Allegory.Module.Customers;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Allegory.Module.EntityFrameworkCore;

[DependsOn(
    typeof(ModuleDomainModule),
    typeof(AbpEntityFrameworkCoreModule)
)]
public class ModuleEntityFrameworkCoreModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAbpDbContext<ModuleDbContext>(options =>
        {
            options.AddRepository<Customer, EfCoreCustomerRepository>();
            options.AddRepository<CustomerGroup, EfCoreCustomerGroupRepository>();
        });
    }
}
