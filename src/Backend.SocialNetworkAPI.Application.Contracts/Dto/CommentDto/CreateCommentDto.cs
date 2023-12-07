using Backend.SocialNetworkAPI.Dto.PhotoDto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.SocialNetworkAPI.Dto.CommentDto
{
    public class CreateCommentDto : CreatePhotoDto
    {
        public string? Content { get; set; }
    }
}