using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Backend.SocialNetworkAPI.EntityFrameworkCore;

public class SocialNetworkAPIHttpApiHostMigrationsDbContext : AbpDbContext<SocialNetworkAPIHttpApiHostMigrationsDbContext>
{
    public SocialNetworkAPIHttpApiHostMigrationsDbContext(DbContextOptions<SocialNetworkAPIHttpApiHostMigrationsDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ConfigureSocialNetworkAPI();
    }
}
