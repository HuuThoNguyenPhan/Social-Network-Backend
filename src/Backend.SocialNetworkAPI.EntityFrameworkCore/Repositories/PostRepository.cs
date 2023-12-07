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
    internal class PostRepository : ITransientDependency, IPostRepository
    {
        private readonly ISocialNetworkAPIDbContext _dbContext;

        public PostRepository(ISocialNetworkAPIDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Post> CreateAsync(Post post)
        {
            try
            {
                await _dbContext.Post.AddRangeAsync(post);
                await _dbContext.SaveChangesAsync();
                return post;
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(SocialNetworkAPIErrorCodes.ERROR_COMMON)
                    .WithData("Message", string.Format("PostRepository-CreateAsync-{0}", ex.Message));
            }
        }

        public async Task<Post> FindAsync(Guid id)
        {
            try
            {
                return await _dbContext.Post.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id)
                    ?? throw new BusinessException(ExceptionCode.NotFoundPostId).WithData("id", id); ;
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
    }
}