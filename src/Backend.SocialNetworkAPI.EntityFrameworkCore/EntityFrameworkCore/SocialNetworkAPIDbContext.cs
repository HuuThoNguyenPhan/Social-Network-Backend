using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Backend.SocialNetworkAPI.EntityFrameworkCore;

[ConnectionStringName(SocialNetworkAPIDbProperties.ConnectionStringName)]
public class SocialNetworkAPIDbContext : AbpDbContext<SocialNetworkAPIDbContext>, ISocialNetworkAPIDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * public DbSet<Question> Questions { get; set; }
     */

    public SocialNetworkAPIDbContext(DbContextOptions<SocialNetworkAPIDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ConfigureSocialNetworkAPI();
    }
}
