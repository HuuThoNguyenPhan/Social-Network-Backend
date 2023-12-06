using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace Backend.SocialNetworkAPI;

[DependsOn(
    typeof(AbpDddDomainModule),
    typeof(SocialNetworkAPIDomainSharedModule)
)]
public class SocialNetworkAPIDomainModule : AbpModule
{

}
