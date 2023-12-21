using Backend.SocialNetworkAPI.Dto.CommentDto;
using Backend.SocialNetworkAPI.ServiceInterface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Backend.SocialNetworkAPI.SocialNetwork
{
    [Authorize]
    [Route("api/comment")]
    public class CommentController : SocialNetworkAPIController, ICommentService
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpPost("/create-comment")]
        public async ValueTask<bool> CreateCommentAsync(CreateCommentDto input)
        {
            return await _commentService.CreateCommentAsync(input);
        }
    }
}