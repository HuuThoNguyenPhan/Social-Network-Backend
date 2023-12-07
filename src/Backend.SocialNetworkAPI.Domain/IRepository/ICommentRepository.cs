using Backend.SocialNetworkAPI.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Backend.SocialNetworkAPI.IRepository
{
    public interface ICommentRepository
    {
        ValueTask<bool> InSertAsync(Comment comment);

        ValueTask<Comment> FindAsync(Guid? id);
    }
}