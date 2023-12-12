using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.SocialNetworkAPI.Dto.LikeDto
{
    public class CheckLikeDto
    {
        public Guid IdUser { get; set; }
        public Guid IdPost { get; set; }
        public Guid? IdComment { get; set; }
    }
}