using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Allegory.StockManagement.EntityFrameworkCore;

public class StockManagementHttpApiHostMigrationsDbContextFactory : IDesignTimeDbContextFactory<StockManagementHttpApiHostMigrationsDbContext>
{
    public StockManagementHttpApiHostMigrationsDbContext CreateDbContext(string[] args)
    {
        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<StockManagementHttpApiHostMigrationsDbContext>()
            .UseSqlServer(configuration.GetConnectionString("StockManagement"));

        return new StockManagementHttpApiHostMigrationsDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
