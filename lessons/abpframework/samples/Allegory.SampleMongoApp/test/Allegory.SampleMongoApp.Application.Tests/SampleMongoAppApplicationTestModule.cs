using Volo.Abp.Modularity;

namespace Allegory.SampleMongoApp;

[DependsOn(
    typeof(SampleMongoAppApplicationModule),
    typeof(SampleMongoAppDomainTestModule)
    )]
public class SampleMongoAppApplicationTestModule : AbpModule
{

}
