using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.SocialNetworkAPI.Dto.LikeDto
{
    public class CreateLikeDto
    {
        public Guid IdUser { get; set; }
        public Guid IdPost { get; set; }
        public Guid? IdComment { get; set; }
    }
}