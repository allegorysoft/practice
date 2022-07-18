using Allegory.Module.Customers;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;
using Volo.Abp.MongoDB;

namespace Allegory.Module.MongoDB;

[DependsOn(
    typeof(ModuleDomainModule),
    typeof(AbpMongoDbModule)
    )]
public class ModuleMongoDbModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddMongoDbContext<ModuleMongoDbContext>(options =>
        {
            options.AddRepository<Customer, MongoCustomerRepository>();
            options.AddRepository<CustomerGroup, MongoCustomerGroupRepository>();
        });
    }
}
