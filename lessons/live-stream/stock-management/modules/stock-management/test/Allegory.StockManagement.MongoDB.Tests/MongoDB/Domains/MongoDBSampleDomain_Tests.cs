using Allegory.StockManagement.Samples;
using Xunit;

namespace Allegory.StockManagement.MongoDB.Domains;

[Collection(MongoTestCollection.Name)]
public class MongoDBSampleDomain_Tests : SampleManager_Tests<StockManagementMongoDbTestModule>
{

}
