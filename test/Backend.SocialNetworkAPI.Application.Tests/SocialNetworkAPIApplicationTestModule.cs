using Volo.Abp.Modularity;

namespace Backend.SocialNetworkAPI;

[DependsOn(
    typeof(SocialNetworkAPIApplicationModule),
    typeof(SocialNetworkAPIDomainTestModule)
    )]
public class SocialNetworkAPIApplicationTestModule : AbpModule
{

}
