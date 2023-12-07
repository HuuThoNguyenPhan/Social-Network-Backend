using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.SocialNetworkAPI.Model
{
    public class Like : BaseModel
    {
        public Guid Id { get; set; }
        public Guid IdPost { get; set; }
        public Guid? IdComment { get; set; }
    }
}