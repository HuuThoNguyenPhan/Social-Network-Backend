using Backend.SocialNetworkAPI.Dto.PostDto;
using System;

using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Backend.SocialNetworkAPI.ServiceInterface
{
    public interface IPostService : IApplicationService
    {
        ValueTask<bool> CreateAsync(CreatePostDto input);

        ValueTask<PostFullInfoDto> GetPostById(Guid id);
    }
}