using Allegory.SampleApp.EntityFrameworkCore;
using Dapper;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.Dapper;
using Volo.Abp.EntityFrameworkCore;

namespace Allegory.SampleApp.Example;

public class DapperExampleRepository : DapperRepository<SecondDbContext>, IExampleRepository
{
    public DapperExampleRepository(IDbContextProvider<SecondDbContext> dbContextProvider) : base(dbContextProvider)
    {

    }

    public async Task GetExecutionPerformance()
    {
        //!!! Connection dispose edildiği an bir UOW bağlıysa rollback işlemi yapar
        using (var connection = await GetDbConnectionAsync())
        {
            var result = connection.Query(@"
            SELECT HttpMethod, MAX(ExecutionDuration) ExecutionDuration
            FROM abpauditlogs
            GROUP BY HttpMethod"
            //,transaction: await GetDbTransactionAsync() => UOW bağlar
            ).ToList();
        }
    }
}
