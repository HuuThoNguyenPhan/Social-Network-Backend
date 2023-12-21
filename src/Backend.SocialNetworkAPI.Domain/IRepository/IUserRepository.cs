using Backend.SocialNetworkAPI.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Backend.SocialNetworkAPI.IRepository
{
    public interface IUserRepository
    {
        Task<User> IsValidUser(User user);

        Task<bool> FindByEmail(string email);

        Task<User> InsertAsync(User user);
    }
}