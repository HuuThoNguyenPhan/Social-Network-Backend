using Backend.SocialNetworkAPI.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Backend.SocialNetworkAPI.IRepository
{
    public interface IPhotoRepository
    {
        ValueTask<bool> InsertListAsync(List<Photo> photos);
    }
}