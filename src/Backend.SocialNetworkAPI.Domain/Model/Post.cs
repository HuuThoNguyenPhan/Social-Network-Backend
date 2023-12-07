using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.SocialNetworkAPI.Model
{
    public class Post : BaseModel
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public string PublishDate { get; set; }
    }
}