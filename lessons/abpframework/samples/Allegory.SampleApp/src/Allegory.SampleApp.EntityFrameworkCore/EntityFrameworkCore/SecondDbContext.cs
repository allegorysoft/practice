using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.IdentityServer.EntityFrameworkCore;

namespace Allegory.SampleApp.EntityFrameworkCore;

[ConnectionStringName("AbpAuditLogging")]
public class SecondDbContext : AbpDbContext<SecondDbContext>
{
    public SecondDbContext(DbContextOptions<SecondDbContext> options) : base(options)
    {

    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ConfigureAuditLogging();
        builder.ConfigureIdentityServer();
    }
}
