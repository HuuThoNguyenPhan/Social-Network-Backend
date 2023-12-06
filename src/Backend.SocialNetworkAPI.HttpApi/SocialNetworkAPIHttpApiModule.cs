using Localization.Resources.AbpUi;
using Backend.SocialNetworkAPI.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace Backend.SocialNetworkAPI;

[DependsOn(
    typeof(SocialNetworkAPIApplicationContractsModule),
    typeof(AbpAspNetCoreMvcModule))]
public class SocialNetworkAPIHttpApiModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddApplicationPartIfNotExists(typeof(SocialNetworkAPIHttpApiModule).Assembly);
        });
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<SocialNetworkAPIResource>()
                .AddBaseTypes(typeof(AbpUiResource));
        });
    }
}
