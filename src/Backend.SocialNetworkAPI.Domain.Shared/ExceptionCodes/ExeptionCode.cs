using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.SocialNetworkAPI.ExceptionCodes
{
    public static class ExceptionCode
    {
        public static readonly string BadRequest = "SocialNetworkAPI:00400";

        public static readonly string InternalServerError = "SocialNetworkAPI:0000";
        public static readonly string InvalidItem = "SocialNetworkAPI:0001";
        public static readonly string NotFound = "SocialNetworkAPI:0002";
        public static readonly string InvalidTicketDetailType = "SocialNetworkAPI:0003";
        public static readonly string ExistEmailUser = "SocialNetworkAPI:0004";
        public static readonly string ErorrCanceledTicket = "SocialNetworkAPI:0005";
        public static readonly string InvalidEmail = "SocialNetworkAPI:0006";
        public static readonly string DuplicatedProductType = "SocialNetworkAPI:0007";
        public static readonly string NotFoundCommentId = "SocialNetworkAPI:0008";
        public static readonly string NotFoundPostId = "SocialNetworkAPI:0009";
        public static readonly string EmailIsExisted = "SocialNetworkAPI:0010";
        public static readonly string InvalidUserLogin = "SocialNetworkAPI:0011";
        public static readonly string ExistImeiOrtherTicket = "SocialNetworkAPI:0012";
        public static readonly string InvalidItemConfirm = "SocialNetworkAPI:0013";
        public static readonly string InvalidIndustryProductType = "SocialNetworkAPI:0014";
        public static readonly string InvalidContentInput = "SocialNetworkAPI:0015";
    }
}