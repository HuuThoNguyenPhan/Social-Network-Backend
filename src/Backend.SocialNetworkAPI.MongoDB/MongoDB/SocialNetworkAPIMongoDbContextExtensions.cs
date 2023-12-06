using Volo.Abp;
using Volo.Abp.MongoDB;

namespace Backend.SocialNetworkAPI.MongoDB;

public static class SocialNetworkAPIMongoDbContextExtensions
{
    public static void ConfigureSocialNetworkAPI(
        this IMongoModelBuilder builder)
    {
        Check.NotNull(builder, nameof(builder));
    }
}
