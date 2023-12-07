using Backend.SocialNetworkAPI.Model;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Backend.SocialNetworkAPI.EntityFrameworkCore;

public static class SocialNetworkAPIDbContextModelCreatingExtensions
{
    public static void ConfigureSocialNetworkAPI(
        this ModelBuilder builder)
    {
        Check.NotNull(builder, nameof(builder));

        /* Configure all entities here. Example:

        builder.Entity<Question>(b =>
        {
            //Configure table & schema name
            b.ToTable(SocialNetworkAPIDbProperties.DbTablePrefix + "Questions", SocialNetworkAPIDbProperties.DbSchema);

            b.ConfigureByConvention();

            //Properties
            b.Property(q => q.Title).IsRequired().HasMaxLength(QuestionConsts.MaxTitleLength);

            //Relations
            b.HasMany(question => question.Tags).WithOne().HasForeignKey(qt => qt.QuestionId);

            //Indexes
            b.HasIndex(q => q.CreationTime);
        });
        */
        builder.Entity<Photo>(b =>
        {
            b.ToTable("Photo");
            b.Property(q => q.Id).IsRequired().ValueGeneratedOnAdd();
        });

        builder.Entity<Post>(b =>
        {
            b.ToTable("Post");
            b.Property(q => q.Id).IsRequired().ValueGeneratedOnAdd();
        });
    }
}