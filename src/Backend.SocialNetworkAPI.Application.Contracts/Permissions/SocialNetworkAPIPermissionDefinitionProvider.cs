using Backend.SocialNetworkAPI.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Backend.SocialNetworkAPI.Permissions;

public class SocialNetworkAPIPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(SocialNetworkAPIPermissions.GroupName, L("Permission:SocialNetworkAPI"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<SocialNetworkAPIResource>(name);
    }
}
