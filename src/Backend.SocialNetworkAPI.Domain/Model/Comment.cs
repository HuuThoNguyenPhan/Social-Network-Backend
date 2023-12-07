using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.SocialNetworkAPI.Model
{
    public class Comment : BaseModel
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public string IdPost { get; set; }
        public string? IdComment { get; set; }
    }
}