using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Sqlite;
using Volo.Abp.IdentityServer.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Allegory.SampleApp.EntityFrameworkCore;

[DependsOn(
    typeof(SampleAppEntityFrameworkCoreModule),
    typeof(SampleAppTestBaseModule),
    typeof(AbpEntityFrameworkCoreSqliteModule)
    )]
public class SampleAppEntityFrameworkCoreTestModule : AbpModule
{
    private SqliteConnection _sqliteConnection;

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        ConfigureInMemorySqlite(context.Services);
    }

    private void ConfigureInMemorySqlite(IServiceCollection services)
    {
        _sqliteConnection = CreateDatabaseAndGetConnection();

        services.Configure<AbpDbContextOptions>(options =>
        {
            options.Configure(context =>
            {
                context.DbContextOptions.UseSqlite(_sqliteConnection);
            });

            options.Configure<IdentityServerDbContext>(context =>
            {
                context.DbContextOptions.UseSqlite(_sqliteConnection);
            });

            options.Configure<AbpAuditLoggingDbContext>(context =>
            {
                context.DbContextOptions.UseSqlite(_sqliteConnection);
            });

            options.Configure<SecondDbContext>(context =>
            {
                context.DbContextOptions.UseSqlite(_sqliteConnection);
            });
        });
    }

    public override void OnApplicationShutdown(ApplicationShutdownContext context)
    {
        _sqliteConnection.Dispose();
    }

    private static SqliteConnection CreateDatabaseAndGetConnection()
    {
        var connection = new SqliteConnection("Data Source=:memory:");
        connection.Open();

        var options = new DbContextOptionsBuilder<SampleAppDbContext>()
            .UseSqlite(connection)
            .Options;

        using (var context = new SampleAppDbContext(options))
        {
            context.GetService<IRelationalDatabaseCreator>().CreateTables();
        }

        var options2 = new DbContextOptionsBuilder<SecondDbContext>()
            .UseSqlite(connection)
            .Options;

        using (var context = new SecondDbContext(options2))
        {
            context.GetService<IRelationalDatabaseCreator>().CreateTables();
        }

        return connection;
    }
}
