using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace Backend.SocialNetworkAPI;

[DependsOn(
    typeof(SocialNetworkAPIApplicationContractsModule),
    typeof(AbpHttpClientModule))]
public class SocialNetworkAPIHttpApiClientModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddHttpClientProxies(
            typeof(SocialNetworkAPIApplicationContractsModule).Assembly,
            SocialNetworkAPIRemoteServiceConsts.RemoteServiceName
        );

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<SocialNetworkAPIHttpApiClientModule>();
        });

    }
}
