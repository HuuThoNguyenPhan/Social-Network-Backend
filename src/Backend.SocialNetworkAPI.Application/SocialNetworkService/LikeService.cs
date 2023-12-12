using Backend.SocialNetworkAPI.Dto.LikeDto;
using Backend.SocialNetworkAPI.IRepository;
using Backend.SocialNetworkAPI.Model;
using Backend.SocialNetworkAPI.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;

namespace Backend.SocialNetworkAPI.SocialNetworkService
{
    public class LikeService : SocialNetworkAPIAppService, ILikeService
    {
        private readonly ILikeRepository _likeRepository;
        private readonly IPostRepository _postRepository;
        private readonly ICommentRepository _commentRepository;

        public LikeService(ILikeRepository likeRepository, IPostRepository postRepository, ICommentRepository commentRepository)
        {
            _likeRepository = likeRepository;
            _postRepository = postRepository;
            _commentRepository = commentRepository;
        }

        public async ValueTask<bool> CreateLikeAsync(CreateLikeDto input)
        {
            try
            {
                await _postRepository.FindAsync(input.IdPost);

                if (input.IdComment is not null)
                {
                    await _commentRepository.FindAsync(input.IdComment);
                }

                var like = await _likeRepository.CheckLiked(new Like
                {
                    CreatedBy = input.IdUser,
                    IdPost = input.IdPost,
                });

                if (like is null)
                {
                    return await _likeRepository.InsertAsync(new Like
                    {
                        CreatedBy = input.IdUser,
                        IdComment = input.IdComment,
                        IdPost = input.IdPost,
                    });
                }

                if (like.IsDeleted == true)
                {
                    like.IsDeleted = false;
                    like.ModifiedTime = DateTime.UtcNow;
                    return await _likeRepository.UpdateAsync(like);
                }
                else
                {
                    like.IsDeleted = true;
                    like.ModifiedTime = DateTime.UtcNow;
                    return await _likeRepository.UpdateAsync(like);
                }
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