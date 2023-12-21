using Backend.SocialNetworkAPI.Dto.LikeDto;
using Backend.SocialNetworkAPI.ServiceInterface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Backend.SocialNetworkAPI.SocialNetwork
{
    [Authorize]
    [Route("api/like")]
    public class LikeController : SocialNetworkAPIController, ILikeService
    {
        private readonly ILikeService _likeService;

        public LikeController(ILikeService likeService)
        {
            _likeService = likeService;
        }

        [HttpPost("create-like")]
        public async ValueTask<bool> CreateLikeAsync(CreateLikeDto input)
        {
            return await _likeService.CreateLikeAsync(input);
        }
    }
}