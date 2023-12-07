using Backend.SocialNetworkAPI.Dto.PhotoDto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.SocialNetworkAPI.Dto.PostDto
{
    public class CreatePostDto
    {
        public string? Content { get; set; }
        public List<InputPhoto>? Photos { get; set; }
    }
}