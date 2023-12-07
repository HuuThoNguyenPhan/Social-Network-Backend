using Backend.SocialNetworkAPI.Dto.PhotoDto;
using Backend.SocialNetworkAPI.ServiceInterface;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Backend.SocialNetworkAPI.SocialNetwork
{
    [Route("api/photo")]
    public class PhotoController : SocialNetworkAPIController, IPhotoService
    {
        private readonly IPhotoService _photoService;

        public PhotoController(IPhotoService photoService)
        {
            _photoService = photoService;
        }

        [HttpPost("/create-photos")]
        public async ValueTask<bool> CreatePhotos(CreatePhotoDto input)
        {
            return await _photoService.CreatePhotos(input);
        }
    }
}