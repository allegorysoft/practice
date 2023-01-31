using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Allegory.NgSampleModule.EntityFrameworkCore;

public class NgSampleModuleHttpApiHostMigrationsDbContextFactory : IDesignTimeDbContextFactory<NgSampleModuleHttpApiHostMigrationsDbContext>
{
    public NgSampleModuleHttpApiHostMigrationsDbContext CreateDbContext(string[] args)
    {
        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<NgSampleModuleHttpApiHostMigrationsDbContext>()
            .UseSqlServer(configuration.GetConnectionString("NgSampleModule"));

        return new NgSampleModuleHttpApiHostMigrationsDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
