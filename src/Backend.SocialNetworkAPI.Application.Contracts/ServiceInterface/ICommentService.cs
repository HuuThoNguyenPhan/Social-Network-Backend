using Backend.SocialNetworkAPI.Dto.CommentDto;
using Backend.SocialNetworkAPI.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Backend.SocialNetworkAPI.ServiceInterface
{
    public interface ICommentService : IApplicationService
    {
        ValueTask<bool> CreateCommentAsync(CreateCommentDto input);
    }
}