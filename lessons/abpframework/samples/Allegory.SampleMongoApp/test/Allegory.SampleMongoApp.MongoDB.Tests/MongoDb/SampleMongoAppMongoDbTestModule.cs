using System;
using Volo.Abp.Data;
using Volo.Abp.Modularity;

namespace Allegory.SampleMongoApp.MongoDB;

[DependsOn(
    typeof(SampleMongoAppTestBaseModule),
    typeof(SampleMongoAppMongoDbModule)
    )]
public class SampleMongoAppMongoDbTestModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        var stringArray = SampleMongoAppMongoDbFixture.ConnectionString.Split('?');
        var connectionString = stringArray[0].EnsureEndsWith('/') +
                                   "Db_" +
                               Guid.NewGuid().ToString("N") + "/?" + stringArray[1];

        Configure<AbpDbConnectionOptions>(options =>
        {
            options.ConnectionStrings.Default = connectionString;
        });
    }
}
