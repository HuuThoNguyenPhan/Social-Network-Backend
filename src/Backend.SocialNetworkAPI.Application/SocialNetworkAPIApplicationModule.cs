using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.Application;

namespace Backend.SocialNetworkAPI;

[DependsOn(
    typeof(SocialNetworkAPIDomainModule),
    typeof(SocialNetworkAPIApplicationContractsModule),
    typeof(AbpDddApplicationModule),
    typeof(AbpAutoMapperModule)
    )]
public class SocialNetworkAPIApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAutoMapperObjectMapper<SocialNetworkAPIApplicationModule>();
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<SocialNetworkAPIApplicationModule>(validate: true);
        });
    }
}
