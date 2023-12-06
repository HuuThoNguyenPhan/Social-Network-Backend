using Backend.SocialNetworkAPI.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Backend.SocialNetworkAPI;

/* Domain tests are configured to use the EF Core provider.
 * You can switch to MongoDB, however your domain tests should be
 * database independent anyway.
 */
[DependsOn(
    typeof(SocialNetworkAPIEntityFrameworkCoreTestModule)
    )]
public class SocialNetworkAPIDomainTestModule : AbpModule
{

}
