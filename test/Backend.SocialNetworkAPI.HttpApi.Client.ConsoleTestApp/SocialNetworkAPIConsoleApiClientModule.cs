using Volo.Abp.Autofac;
using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace Backend.SocialNetworkAPI;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(SocialNetworkAPIHttpApiClientModule),
    typeof(AbpHttpClientIdentityModelModule)
    )]
public class SocialNetworkAPIConsoleApiClientModule : AbpModule
{

}
