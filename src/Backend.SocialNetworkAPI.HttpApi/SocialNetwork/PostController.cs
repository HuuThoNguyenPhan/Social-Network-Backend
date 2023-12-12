using Backend.SocialNetworkAPI.Dto.PostDto;
using Backend.SocialNetworkAPI.ServiceInterface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Backend.SocialNetworkAPI.SocialNetwork
{
    [Route("api/post")]
    public class PostController : SocialNetworkAPIController, IPostService
    {
        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpPost("/create-new")]
        public async ValueTask<bool> CreateAsync(CreatePostDto input)
        {
            return await _postService.CreateAsync(input);
        }

        [HttpGet("/get-detail-by-id")]
        public async ValueTask<PostFullInfoDto> GetPostById(Guid id)
        {
            return await _postService.GetPostById(id);
        }
    }
}