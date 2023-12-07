using Backend.SocialNetworkAPI.Dto.PhotoDto;
using Backend.SocialNetworkAPI.Dto.PostDto;
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
    public class PostService : SocialNetworkAPIAppService, IPostService
    {
        private readonly IPostRepository _postRepository;
        private readonly IPhotoService _photoService;

        public PostService(IPostRepository postRepository, IPhotoService photoService)
        {
            _postRepository = postRepository;
            _photoService = photoService;
        }

        public async ValueTask<bool> CreateAsync(CreatePostDto input)
        {
            try
            {
                if (String.IsNullOrWhiteSpace(input.Content) && input.Photos is null)
                {
                    throw new BusinessException(ExceptionCode.InvalidContentInput).WithData("{Object}", "Bài viết");
                }
                var post = await _postRepository.CreateAsync(new Post
                {
                    Content = input.Content,
                    PublishDate = DateTime.Now.ToString(),
                });

                if (input.Photos != null)
                {
                    await _photoService.CreatePhotos(new CreatePhotoDto
                    {
                        IdPost = post.Id,
                        InputPhotos = input.Photos,
                    });
                }
                return true;
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

        public async ValueTask<PostFullInfoDto> GetPostById(Guid id)
        {
            return ObjectMapper.Map<Post, PostFullInfoDto>(await _postRepository.FindAsync(id));
        }
    }
}