using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Allegory.SampleApp.EntityFrameworkCore;

public class SecondDbContextFactory : IDesignTimeDbContextFactory<SecondDbContext>
{
    public SecondDbContext CreateDbContext(string[] args)
    {
        SampleAppEfCoreEntityExtensionMappings.Configure();

        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<SecondDbContext>()
            .UseMySql(configuration.GetConnectionString("AbpAuditLogging"),ServerVersion.AutoDetect(configuration.GetConnectionString("AbpAuditLogging")));

        return new SecondDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../Allegory.SampleApp.DbMigrator/"))
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}

