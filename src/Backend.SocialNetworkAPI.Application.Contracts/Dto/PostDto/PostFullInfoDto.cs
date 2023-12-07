using Backend.SocialNetworkAPI.Dto.PhotoDto;
using System;
using System.Collections.Generic;

namespace Backend.SocialNetworkAPI.Dto.PostDto
{
    public class PostFullInfoDto : BaseDto
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public string PublishDate { get; set; }
        public List<PhotoInfoDto>? Photos { get; set; } = new List<PhotoInfoDto>();
    }
}