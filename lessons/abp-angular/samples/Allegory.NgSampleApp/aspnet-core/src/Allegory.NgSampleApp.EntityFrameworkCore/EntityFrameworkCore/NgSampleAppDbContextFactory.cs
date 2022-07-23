using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Allegory.NgSampleApp.EntityFrameworkCore;

/* This class is needed for EF Core console commands
 * (like Add-Migration and Update-Database commands) */
public class NgSampleAppDbContextFactory : IDesignTimeDbContextFactory<NgSampleAppDbContext>
{
    public NgSampleAppDbContext CreateDbContext(string[] args)
    {
        NgSampleAppEfCoreEntityExtensionMappings.Configure();

        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<NgSampleAppDbContext>()
            .UseSqlServer(configuration.GetConnectionString("Default"));

        return new NgSampleAppDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../Allegory.NgSampleApp.DbMigrator/"))
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
