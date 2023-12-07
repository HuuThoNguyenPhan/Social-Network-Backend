using Backend.SocialNetworkAPI.Dto.CommentDto;
using Backend.SocialNetworkAPI.Dto.PhotoDto;
using Backend.SocialNetworkAPI.ExceptionCodes;
using Backend.SocialNetworkAPI.IRepository;
using Backend.SocialNetworkAPI.Model;
using Backend.SocialNetworkAPI.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp;

namespace Backend.SocialNetworkAPI.SocialNetworkService
{
    public class CommentService : SocialNetworkAPIAppService, ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IPostRepository _postRepository;
        private readonly IPhotoService _photoService;

        public CommentService(ICommentRepository commentRepository, IPostRepository postRepository, IPhotoService photoService)
        {
            _commentRepository = commentRepository;
            _postRepository = postRepository;
            _photoService = photoService;
        }

        public async ValueTask<bool> CreateCommentAsync(CreateCommentDto input)
        {
            try
            {
                if (String.IsNullOrWhiteSpace(input.Content) && input.InputPhotos is null)
                {
                    throw new BusinessException(ExceptionCode.InvalidContentInput).WithData("Object", "Bình luận");
                }
                await _postRepository.FindAsync(input.IdPost);

                await _commentRepository.InSertAsync(new Comment
                {
                    Content = input.Content,
                    IdPost = input.IdPost.ToString(),
                });

                if (input.InputPhotos is not null)
                {
                    await _photoService.CreatePhotos(new CreatePhotoDto
                    {
                        InputPhotos = input.InputPhotos,
                        IdComment = input.IdComment,
                        IdPost = input.IdPost
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
    }
}