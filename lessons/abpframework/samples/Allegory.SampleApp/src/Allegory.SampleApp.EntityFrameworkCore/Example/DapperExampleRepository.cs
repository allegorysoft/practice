using Allegory.SampleApp.EntityFrameworkCore;
using Dapper;
using System;
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

    public virtual async Task GetExecutionPerformanceAsync()
    {
        var connection = await GetDbConnectionAsync();

        var result = (await connection.QueryAsync(@"
            SELECT HttpMethod, MAX(ExecutionDuration) ExecutionDuration
            FROM abpauditlogs
            GROUP BY HttpMethod",
            transaction: await GetDbTransactionAsync())).ToList();
    }

    public virtual async Task ItThrowsDisposeExceptionAsync()
    {
        //!!! Connection dispose edildikten sonra aynı DbContext için tekrar SQL isteği atıldığında(Aynı DbContext'i kullanan farklı bir repository olsa dahi her UOW için bir connection oluşturur) ObjectDisposed exception hatası alınır
        //https://github.com/abpframework/abp/blob/ff43bdc4e8f907508345a15ad81fece82632ad5e/framework/src/Volo.Abp.EntityFrameworkCore/Volo/Abp/Uow/EntityFrameworkCore/UnitOfWorkDbContextProvider.cs#L81

        using (var connection = await GetDbConnectionAsync())
        {
            var result = (await connection.QueryAsync("SELECT 1",
            transaction: await GetDbTransactionAsync())).ToList();
        }
    }

    public virtual async Task WithoutTransactionAsync()
    {
        //!!! Eğer transactional UOW varsa ve transaction parametresi verilmezse hata verir 

        var connection = await GetDbConnectionAsync();
        var result = (await connection.QueryAsync("SELECT 1")).ToList();
    }

    public virtual async Task WithTransactionAsync()
    {
        //!!! Transactional UOW varken connection dispose edilirse rollback işlemi yapar

        using (var connection = await GetDbConnectionAsync())
        {
            await connection.ExecuteAsync(@"
            INSERT INTO abpauditlogs(Id, ExecutionTime ,ExecutionDuration) 
            VALUES(@Id, @ExecutionTime, @ExecutionDuration)",
            param: new
            {
                Id = Guid.Empty.ToString(),
                ExecutionTime = DateTime.Now,
                ExecutionDuration = 0
            },
            transaction: await GetDbTransactionAsync());
        }
    }
}
