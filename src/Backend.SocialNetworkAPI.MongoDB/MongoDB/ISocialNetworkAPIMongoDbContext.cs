using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace Backend.SocialNetworkAPI.MongoDB;

[ConnectionStringName(SocialNetworkAPIDbProperties.ConnectionStringName)]
public interface ISocialNetworkAPIMongoDbContext : IAbpMongoDbContext
{
    /* Define mongo collections here. Example:
     * IMongoCollection<Question> Questions { get; }
     */
}
