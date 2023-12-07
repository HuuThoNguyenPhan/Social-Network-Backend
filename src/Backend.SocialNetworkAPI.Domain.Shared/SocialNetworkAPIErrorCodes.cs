namespace Backend.SocialNetworkAPI;

public static class SocialNetworkAPIErrorCodes
{
    //Add your business exception error codes here...
    public static string ERROR_COMMON = "SocialNetworkAPI:99901";

    public static string ERROR_FILEFORMAT_INVALID = "SocialNetworkAPI:10100";
    public static string ERROR_FILENAME_INVALID = "SocialNetworkAPI:10101";
    public static string ERROR_FILESTREAM_INVALID = "SocialNetworkAPI:10102";
    public static string ERROR_INPUT_INVALID = "SocialNetworkAPI:10103";
    public static string ERROR_UNAUTHORIZED = "SocialNetworkAPI:10104";
    public static string ERROR_INVALID_TICKET_STATUS = "SocialNetworkAPI:10105";
    public static string ERROR_ITEM_ALREADY_EXITS_IN_TICKETCONFIRM = "SocialNetworkAPI:10106";
    public static string ERROR_TYPE_EXITS_IN_DIFFERENT_TICKET = "SocialNetworkAPI:10107";
    public static string ERROR_CANNOT_FIND_TICKET = "SocialNetworkAPI:10108";
    public static string ERROR_ITEM_HAVE_IMEI = "SocialNetworkAPI:10109";
    public static string ERROR_CANNOT_FIND_TICKET_CONFIRM_CODE = "SocialNetworkAPI:10113";
    public static string ERROR_NOT_MATCH_INDUSTRY_OR_TYPE = "SocialNetworkAPI:10110";
    public static string ERROR_INVENTORY_NOT_DEVIANTE = "SocialNetworkAPI:20000";
    public static string ERROR_TYPE_ALREADY_HAVE_PROCESSING_TICKETCONFIRM = "SocialNetworkAPI:10114";
    public static string ERROR_MISSING_PICK_TYPE_IN_TICKET = "SocialNetworkAPI:10115";
}