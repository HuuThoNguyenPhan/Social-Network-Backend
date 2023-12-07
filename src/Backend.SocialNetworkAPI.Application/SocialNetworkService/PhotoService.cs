using Backend.SocialNetworkAPI.Dto.PhotoDto;
using Backend.SocialNetworkAPI.ExceptionCodes;
using Backend.SocialNetworkAPI.IRepository;
using Backend.SocialNetworkAPI.Model;
using Backend.SocialNetworkAPI.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Volo.Abp;

namespace Backend.SocialNetworkAPI.SocialNetworkService
{
    public class PhotoService : SocialNetworkAPIAppService, IPhotoService
    {
        private readonly IPhotoRepository _photoRepository;
        private readonly IPostRepository _postRepository;
        private readonly ICommentRepository _commentRepository;

        public PhotoService(IPhotoRepository photoRepository,
            IPostRepository postRepository,
            ICommentRepository commentRepository)
        {
            _photoRepository = photoRepository;
            _postRepository = postRepository;
            _commentRepository = commentRepository;
        }

        public async ValueTask<bool> CreatePhotos(CreatePhotoDto input)
        {
            try
            {
                await _postRepository.FindAsync(input.IdPost);

                if (input.IdComment is not null)
                {
                    await _commentRepository.FindAsync(input.IdComment);
                }

                List<Photo> photos = new List<Photo>();
                foreach (var item in input.InputPhotos)
                {
                    photos.Add(new Photo
                    {
                        IdPost = input.IdPost.ToString(),
                        IdComment = input.IdComment.ToString() ?? string.Empty,
                        Url = item.Url,
                    });
                }

                return await _photoRepository.InsertListAsync(photos);
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
    }
}