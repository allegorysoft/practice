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
        //!!! Eğer transactional UOW varsa ve transaction parametresi verilmezse hata verir 
        //!!! Transactional UOW varken connection dispose edilirse rollback işlemi yapar
        //!!! Connection dispose edildikten sonra aynı repository'nin farklı bir metodu çağrılırsa hata verir

        var connection = await GetDbConnectionAsync();

        var result = connection.Query(@"
            SELECT HttpMethod, MAX(ExecutionDuration) ExecutionDuration
            FROM abpauditlogs
            GROUP BY HttpMethod",
            transaction: await GetDbTransactionAsync()).ToList();

    }

}
