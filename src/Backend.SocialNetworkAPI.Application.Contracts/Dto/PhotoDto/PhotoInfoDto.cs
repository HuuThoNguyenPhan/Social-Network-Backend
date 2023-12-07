using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.SocialNetworkAPI.Dto.PhotoDto
{
    public class PhotoInfoDto
    {
        public Guid Id { get; set; }
        public string Url { get; set; }
        public short Type { get; set; }
    }
}