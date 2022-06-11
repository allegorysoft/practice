using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Allegory.Module.EntityFrameworkCore;

public class ModuleHttpApiHostMigrationsDbContextFactory : IDesignTimeDbContextFactory<ModuleHttpApiHostMigrationsDbContext>
{
    public ModuleHttpApiHostMigrationsDbContext CreateDbContext(string[] args)
    {
        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<ModuleHttpApiHostMigrationsDbContext>()
            .UseSqlServer(configuration.GetConnectionString("Module"));

        return new ModuleHttpApiHostMigrationsDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
