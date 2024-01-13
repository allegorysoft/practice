using Allegory.StockManagement.MongoDB;
using Allegory.StockManagement.Samples;
using Xunit;

namespace Allegory.StockManagement.MongoDb.Applications;

[Collection(MongoTestCollection.Name)]
public class MongoDBSampleAppService_Tests : SampleAppService_Tests<StockManagementMongoDbTestModule>
{

}
