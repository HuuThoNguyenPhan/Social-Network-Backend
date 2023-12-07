using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Backend.SocialNetworkAPI.Dto.PhotoDto;

namespace Backend.SocialNetworkAPI.ServiceInterface
{
    public interface IPhotoService : IApplicationService
    {
        ValueTask<bool> CreatePhotos(CreatePhotoDto input);
    }
}