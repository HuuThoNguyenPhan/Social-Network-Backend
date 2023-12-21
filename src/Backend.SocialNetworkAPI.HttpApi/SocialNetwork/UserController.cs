using Backend.SocialNetworkAPI.Dto.UserDto;
using Backend.SocialNetworkAPI.ServiceInterface;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Backend.SocialNetworkAPI.SocialNetwork
{
    [Route("api/user")]
    public class UserController : SocialNetworkAPIController, IUserService
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("/login")]
        public async ValueTask<string> AuthenticateAsync(UserAuthDto input)
        {
            return await _userService.AuthenticateAsync(input);
        }

        [HttpPost("/registration")]
        public async ValueTask<string> RegisterUserAsync(UserAuthDto input)
        {
            return await _userService.RegisterUserAsync(input);
        }
    }
}