using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;
using Volo.Abp.MongoDB;

namespace Backend.SocialNetworkAPI.MongoDB;

[DependsOn(
    typeof(SocialNetworkAPIDomainModule),
    typeof(AbpMongoDbModule)
    )]
public class SocialNetworkAPIMongoDbModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddMongoDbContext<SocialNetworkAPIMongoDbContext>(options =>
        {
                /* Add custom repositories here. Example:
                 * options.AddRepository<Question, MongoQuestionRepository>();
                 */
        });
    }
}
