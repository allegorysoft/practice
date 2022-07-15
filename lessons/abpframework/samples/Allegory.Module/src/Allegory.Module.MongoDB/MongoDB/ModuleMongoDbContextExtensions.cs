using Allegory.Module.Customers;
using Volo.Abp;
using Volo.Abp.MongoDB;

namespace Allegory.Module.MongoDB;

public static class ModuleMongoDbContextExtensions
{
    public static void ConfigureModule(
        this IMongoModelBuilder builder)
    {
        Check.NotNull(builder, nameof(builder));

        builder.Entity<Customer>(b =>
        {
            b.CollectionName = ModuleDbProperties.DbTablePrefix + "Customers";
        });

        builder.Entity<CustomerGroup>(b =>
        {
            b.CollectionName = ModuleDbProperties.DbTablePrefix + "CustomerGroups";
        });
    }
}
