using Microsoft.EntityFrameworkCore;
using Volo.Abp;

namespace Allegory.NgSampleModule.EntityFrameworkCore;

public static class NgSampleModuleDbContextModelCreatingExtensions
{
    public static void ConfigureNgSampleModule(
        this ModelBuilder builder)
    {
        Check.NotNull(builder, nameof(builder));

        /* Configure all entities here. Example:

        builder.Entity<Question>(b =>
        {
            //Configure table & schema name
            b.ToTable(NgSampleModuleDbProperties.DbTablePrefix + "Questions", NgSampleModuleDbProperties.DbSchema);

            b.ConfigureByConvention();

            //Properties
            b.Property(q => q.Title).IsRequired().HasMaxLength(QuestionConsts.MaxTitleLength);

            //Relations
            b.HasMany(question => question.Tags).WithOne().HasForeignKey(qt => qt.QuestionId);

            //Indexes
            b.HasIndex(q => q.CreationTime);
        });
        */
    }
}
