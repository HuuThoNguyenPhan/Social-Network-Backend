using Backend.SocialNetworkAPI.Dto.UserDto;
using Backend.SocialNetworkAPI.ExceptionCodes;
using Backend.SocialNetworkAPI.IRepository;
using Backend.SocialNetworkAPI.Model;
using Backend.SocialNetworkAPI.ServiceInterface;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.FileSystemGlobbing.Internal;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Volo.Abp;

namespace Backend.SocialNetworkAPI.SocialNetworkService
{
    public class UserService : SocialNetworkAPIAppService, IUserService
    {
        private readonly IConfiguration _configuration;
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }

        public async ValueTask<string> AuthenticateAsync(UserAuthDto input)
        {
            try
            {
                var user = await _userRepository.IsValidUser(new User
                {
                    Email = input.Email,
                    Password = input.Password,
                });

                if (user is null)
                {
                    throw new BusinessException(ExceptionCode.InvalidUserLogin);
                }

                return GenerateToken(user);
            }
            catch (BusinessException bex)
            {
                throw bex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async ValueTask<string> RegisterUserAsync(UserAuthDto input)
        {
            try
            {
                if (!verifiedEmail(input.Email))
                {
                    throw new BusinessException(ExceptionCode.InvalidEmail).WithData("email", input.Email);
                }

                if (await _userRepository.FindByEmail(input.Email))
                {
                    throw new BusinessException(ExceptionCode.EmailIsExisted);
                }

                var user = await _userRepository.InsertAsync(new User
                {
                    Email = input.Email,
                    Password = input.Password,
                });
                return GenerateToken(user);
            }
            catch (BusinessException bex)
            {
                throw bex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool verifiedEmail(string email) => Regex.Match(email, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$").Success;

        private string GenerateToken(User user)
        {
            var key = new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"])), SecurityAlgorithms.HmacSha256);
            var security = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: new List<Claim>
                { // Tên người dùng
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Name, user.LastName + user.FirstName),// Email
                    new Claim(ClaimTypes.Role, user.Role.ToString()), // Vai trò người dùng
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()), // ID người dùng
                },
                expires: DateTime.Now.AddDays(30),
                signingCredentials: key
            );
            var token = new JwtSecurityTokenHandler().WriteToken(security);
            return token;
        }
    }
}