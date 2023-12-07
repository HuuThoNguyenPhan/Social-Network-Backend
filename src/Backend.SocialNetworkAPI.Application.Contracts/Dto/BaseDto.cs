using System;

namespace Backend.SocialNetworkAPI.Dto
{
    public class BaseDto
    {
        public DateTime CreatedTime { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime ModifiedTime { get; set; }
        public Guid ModifiedBy { get; set; }
        public short Status { get; set; }
        public bool IsDeleted { get; set; }
    }
}