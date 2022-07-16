using Allegory.SampleMongoApp.MongoDB;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories.MongoDB;
using Volo.Abp.MongoDB;

namespace Allegory.SampleMongoApp.MongoDb
{
    public class MyRepositoryBase<TEntity>
        : MongoDbRepository<SampleMongoAppMongoDbContext, TEntity>
        where TEntity : class, IEntity
    {
        public MyRepositoryBase(IMongoDbContextProvider<SampleMongoAppMongoDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
            
        }
    }

    public class MyRepositoryBase<TEntity, TKey>
        : MongoDbRepository<SampleMongoAppMongoDbContext, TEntity, TKey>
        where TEntity : class, IEntity<TKey>
    {
        public MyRepositoryBase(IMongoDbContextProvider<SampleMongoAppMongoDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public override Task<List<TEntity>> GetPagedListAsync(int skipCount, int maxResultCount, string sorting, bool includeDetails = false, CancellationToken cancellationToken = default)
        {
            //Custom logic
            return base.GetPagedListAsync(skipCount, maxResultCount, sorting, includeDetails, cancellationToken);
        }
    }
}
