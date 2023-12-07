using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.SocialNetworkAPI.Model
{
    public class BaseModel
    {
        public DateTime CreatedTime { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime ModifiedTime { get; set; }
        public Guid ModifiedBy { get; set; }
        public short Status { get; set; }
        public bool IsDeleted { get; set; }

        public BaseModel()
        {
            CreatedTime = DateTime.Now;
            ModifiedTime = DateTime.Now;
        }
    }
}