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
    public class CommentRepository : ITransientDependency, ICommentRepository
    {
        private readonly ISocialNetworkAPIDbContext _dbContext;

        public CommentRepository(ISocialNetworkAPIDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async ValueTask<Comment> FindAsync(Guid? id)
        {
            try
            {
                return await _dbContext.Comment.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id)
                    ?? throw new BusinessException(ExceptionCode.NotFoundCommentId).WithData("id", id); ;
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

        public async ValueTask<bool> InSertAsync(Comment comment)
        {
            try
            {
                await _dbContext.Comment.AddAsync(comment);
                return await _dbContext.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(SocialNetworkAPIErrorCodes.ERROR_COMMON)
                    .WithData("Message", string.Format("CommentRepository-InSertAsync-{0}", ex.Message));
            }
        }
    }
}