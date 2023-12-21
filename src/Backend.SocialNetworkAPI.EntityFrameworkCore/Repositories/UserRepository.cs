using Backend.SocialNetworkAPI.EntityFrameworkCore;
using Backend.SocialNetworkAPI.ExceptionCodes;
using Backend.SocialNetworkAPI.IRepository;
using Backend.SocialNetworkAPI.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.DependencyInjection;

namespace Backend.SocialNetworkAPI.Repositories
{
    public class UserRepository : ITransientDependency, IUserRepository
    {
        private readonly ISocialNetworkAPIDbContext _dbContext;

        public UserRepository(ISocialNetworkAPIDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> FindByEmail(string email)
        {
            try
            {
                return await _dbContext.User.AsNoTracking().AnyAsync(u => u.Email == email);
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(SocialNetworkAPIErrorCodes.ERROR_COMMON)
                   .WithData("Message", string.Format("UserRepository-FindByEmail-{0}", ex.Message));
            }
        }

        public async Task<User> InsertAsync(User user)
        {
            try
            {
                await _dbContext.User.AddAsync(user);
                await _dbContext.SaveChangesAsync();
                return user;
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(SocialNetworkAPIErrorCodes.ERROR_COMMON)
                   .WithData("Message", string.Format("UserRepository-InsertAsync-{0}", ex.Message));
            }
        }

        public async Task<User> IsValidUser(User user)
        {
            try
            {
                return await _dbContext.User.AsNoTracking().FirstOrDefaultAsync(u => u.Email == user.Email && u.Password == user.Password);
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(SocialNetworkAPIErrorCodes.ERROR_COMMON)
                   .WithData("Message", string.Format("UserRepository-IsValidUser-{0}", ex.Message));
            }
        }
    }
}