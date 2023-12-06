using Backend.SocialNetworkAPI.Localization;
using Volo.Abp.Application.Services;

namespace Backend.SocialNetworkAPI;

public abstract class SocialNetworkAPIAppService : ApplicationService
{
    protected SocialNetworkAPIAppService()
    {
        LocalizationResource = typeof(SocialNetworkAPIResource);
        ObjectMapperContext = typeof(SocialNetworkAPIApplicationModule);
    }
}
