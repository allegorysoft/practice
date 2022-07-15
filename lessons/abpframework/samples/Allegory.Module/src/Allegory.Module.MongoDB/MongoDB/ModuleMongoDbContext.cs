using Allegory.Module.Customers;
using MongoDB.Driver;
using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace Allegory.Module.MongoDB;

[ConnectionStringName(ModuleDbProperties.ConnectionStringName)]
public class ModuleMongoDbContext : AbpMongoDbContext, IModuleMongoDbContext
{
    /* Add mongo collections here. Example:
     * public IMongoCollection<Question> Questions => Collection<Question>();
     */

    public IMongoCollection<Customer> Customers => Collection<Customer>();
    public IMongoCollection<CustomerGroup> CustomerGroups => Collection<CustomerGroup>();

    protected override void CreateModel(IMongoModelBuilder modelBuilder)
    {
        base.CreateModel(modelBuilder);

        modelBuilder.ConfigureModule();
    }
}
