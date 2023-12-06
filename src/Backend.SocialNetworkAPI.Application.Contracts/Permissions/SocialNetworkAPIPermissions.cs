using Volo.Abp.Reflection;

namespace Backend.SocialNetworkAPI.Permissions;

public class SocialNetworkAPIPermissions
{
    public const string GroupName = "SocialNetworkAPI";

    public static string[] GetAll()
    {
        return ReflectionHelper.GetPublicConstantsRecursively(typeof(SocialNetworkAPIPermissions));
    }
}
