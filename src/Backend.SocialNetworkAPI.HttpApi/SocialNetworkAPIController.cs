using Backend.SocialNetworkAPI.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Backend.SocialNetworkAPI;

public abstract class SocialNetworkAPIController : AbpControllerBase
{
    protected SocialNetworkAPIController()
    {
        LocalizationResource = typeof(SocialNetworkAPIResource);
    }
}
