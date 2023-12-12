using Backend.SocialNetworkAPI.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Backend.SocialNetworkAPI.IRepository
{
    public interface ILikeRepository
    {
        ValueTask<bool> InsertAsync(Like like);

        ValueTask<Like> CheckLiked(Like like);

        ValueTask<bool> UpdateAsync(Like like);
    }
}