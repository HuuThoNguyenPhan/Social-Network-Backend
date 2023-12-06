namespace Backend.SocialNetworkAPI;

public static class SocialNetworkAPIDbProperties
{
    public static string DbTablePrefix { get; set; } = "SocialNetworkAPI";

    public static string? DbSchema { get; set; } = null;

    public const string ConnectionStringName = "SocialNetworkAPI";
}
