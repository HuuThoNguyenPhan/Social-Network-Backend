using Backend.SocialNetworkAPI.EntityFrameworkCore;
using Backend.SocialNetworkAPI.IRepository;
using Backend.SocialNetworkAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.DependencyInjection;

namespace Backend.SocialNetworkAPI.Repositories
{
    public class PhotoRepository : ITransientDependency, IPhotoRepository
    {
        private readonly ISocialNetworkAPIDbContext _dbContext;

        public PhotoRepository(ISocialNetworkAPIDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async ValueTask<bool> InsertListAsync(List<Photo> photos)
        {
            try
            {
                await _dbContext.Photo.AddRangeAsync(photos);
                return await _dbContext.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(SocialNetworkAPIErrorCodes.ERROR_COMMON)
                    .WithData("Message", string.Format("PhotoRepository-InsertListAsync-{0}", ex.Message));
            }
        }
    }
}