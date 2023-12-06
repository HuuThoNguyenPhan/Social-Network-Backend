using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace Backend.SocialNetworkAPI.MongoDB;

[ConnectionStringName(SocialNetworkAPIDbProperties.ConnectionStringName)]
public class SocialNetworkAPIMongoDbContext : AbpMongoDbContext, ISocialNetworkAPIMongoDbContext
{
    /* Add mongo collections here. Example:
     * public IMongoCollection<Question> Questions => Collection<Question>();
     */

    protected override void CreateModel(IMongoModelBuilder modelBuilder)
    {
        base.CreateModel(modelBuilder);

        modelBuilder.ConfigureSocialNetworkAPI();
    }
}
