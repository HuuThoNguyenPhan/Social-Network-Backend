using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Backend.SocialNetworkAPI.EntityFrameworkCore;

public class SocialNetworkAPIHttpApiHostMigrationsDbContextFactory : IDesignTimeDbContextFactory<SocialNetworkAPIHttpApiHostMigrationsDbContext>
{
    public SocialNetworkAPIHttpApiHostMigrationsDbContext CreateDbContext(string[] args)
    {
        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<SocialNetworkAPIHttpApiHostMigrationsDbContext>()
            .UseSqlServer(configuration.GetConnectionString("SocialNetworkAPI"));

        return new SocialNetworkAPIHttpApiHostMigrationsDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
