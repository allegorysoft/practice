using Allegory.SampleApp.EntityFrameworkCore;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.Dapper;
using Volo.Abp.EntityFrameworkCore;

namespace Allegory.SampleApp.Example;

public class DapperExampleRepository : DapperRepository<SecondDbContext>, IExampleRepository
{
    public DapperExampleRepository(IDbContextProvider<SecondDbContext> dbContextProvider) : base(dbContextProvider)
    {

    }

    public async Task Do()
    {
        var dbConnection = await GetDbConnectionAsync();
    }
}
