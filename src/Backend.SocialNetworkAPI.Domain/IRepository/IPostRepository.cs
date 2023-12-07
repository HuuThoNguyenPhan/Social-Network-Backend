using Backend.SocialNetworkAPI.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Backend.SocialNetworkAPI.IRepository
{
    public interface IPostRepository
    {
        Task<Post> CreateAsync(Post post);

        Task<Post> FindAsync(Guid id);
    }
}