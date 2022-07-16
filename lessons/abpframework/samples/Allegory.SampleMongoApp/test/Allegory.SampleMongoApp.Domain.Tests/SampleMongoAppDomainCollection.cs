using Allegory.SampleMongoApp.MongoDB;
using Xunit;

namespace Allegory.SampleMongoApp;

[CollectionDefinition(SampleMongoAppTestConsts.CollectionDefinitionName)]
public class SampleMongoAppDomainCollection : SampleMongoAppMongoDbCollectionFixtureBase
{

}
