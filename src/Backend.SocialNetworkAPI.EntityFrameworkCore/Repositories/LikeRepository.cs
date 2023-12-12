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
    internal class LikeRepository : ITransientDependency, ILikeRepository
    {
        private readonly ISocialNetworkAPIDbContext _dbContext;

        public LikeRepository(ISocialNetworkAPIDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async ValueTask<Like> CheckLiked(Like like)
        {
            try
            {
                return await _dbContext.Like.AsNoTracking().FirstOrDefaultAsync(x => x.IdPost == like.IdPost && x.CreatedBy == like.CreatedBy);
            }
            catch (BusinessException bex)
            {
                throw bex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async ValueTask<bool> InsertAsync(Like like)
        {
            try
            {
                await _dbContext.Like.AddAsync(like);
                return _dbContext.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(SocialNetworkAPIErrorCodes.ERROR_COMMON)
                    .WithData("Message", string.Format("LikeRepository-InsertAsync-{0}", ex.Message));
            }
        }

        public async ValueTask<bool> UpdateAsync(Like like)
        {
            try
            {
                _dbContext.Like.Update(like);
                return _dbContext.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(SocialNetworkAPIErrorCodes.ERROR_COMMON)
                    .WithData("Message", string.Format("LikeRepository-InsertAsync-{0}", ex.Message));
            }
        }
    }
}