using Allegory.SampleMongoApp.MongoDB;
using Volo.Abp.Modularity;

namespace Allegory.SampleMongoApp;

[DependsOn(
    typeof(SampleMongoAppMongoDbTestModule)
    )]
public class SampleMongoAppDomainTestModule : AbpModule
{

}
