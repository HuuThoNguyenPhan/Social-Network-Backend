using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Backend.SocialNetworkAPI.EntityFrameworkCore;

[ConnectionStringName(SocialNetworkAPIDbProperties.ConnectionStringName)]
public interface ISocialNetworkAPIDbContext : IEfCoreDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * DbSet<Question> Questions { get; }
     */
}
