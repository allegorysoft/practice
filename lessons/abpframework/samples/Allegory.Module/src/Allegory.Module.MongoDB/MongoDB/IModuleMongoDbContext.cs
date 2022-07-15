using Allegory.Module.Customers;
using MongoDB.Driver;
using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace Allegory.Module.MongoDB;

[ConnectionStringName(ModuleDbProperties.ConnectionStringName)]
public interface IModuleMongoDbContext : IAbpMongoDbContext
{
    IMongoCollection<Customer> Customers { get; }
    IMongoCollection<CustomerGroup> CustomerGroups { get; }
}
