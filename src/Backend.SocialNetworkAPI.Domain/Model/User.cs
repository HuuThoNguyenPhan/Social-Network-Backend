using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.SocialNetworkAPI.Model
{
    public class User : BaseModel
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string DateOfBirth { get; set; }
        public bool Gender { get; set; }
        public string Avatar { get; set; }
        public short Role { get; set; }
    }
}