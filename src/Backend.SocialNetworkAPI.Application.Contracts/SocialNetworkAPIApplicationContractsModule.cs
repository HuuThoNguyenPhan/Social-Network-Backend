using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;

namespace Backend.SocialNetworkAPI;

[DependsOn(
    typeof(SocialNetworkAPIDomainSharedModule),
    typeof(AbpDddApplicationContractsModule),
    typeof(AbpAuthorizationModule)
    )]
public class SocialNetworkAPIApplicationContractsModule : AbpModule
{

}
