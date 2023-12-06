using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Backend.SocialNetworkAPI.EntityFrameworkCore;

[DependsOn(
    typeof(SocialNetworkAPIDomainModule),
    typeof(AbpEntityFrameworkCoreModule)
)]
public class SocialNetworkAPIEntityFrameworkCoreModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAbpDbContext<SocialNetworkAPIDbContext>(options =>
        {
                /* Add custom repositories here. Example:
                 * options.AddRepository<Question, EfCoreQuestionRepository>();
                 */
        });
    }
}
