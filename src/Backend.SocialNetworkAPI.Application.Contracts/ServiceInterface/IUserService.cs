using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Backend.SocialNetworkAPI.ServiceInterface
{
    public interface IUserService : IApplicationService
    {
        public ValueTask<bool> Login();
    }
}