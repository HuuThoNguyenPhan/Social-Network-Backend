using AutoMapper;
using Backend.SocialNetworkAPI.Dto.CommentDto;
using Backend.SocialNetworkAPI.Dto.PhotoDto;
using Backend.SocialNetworkAPI.Dto.PostDto;
using Backend.SocialNetworkAPI.Model;

namespace Backend.SocialNetworkAPI;

public class SocialNetworkAPIApplicationAutoMapperProfile : Profile
{
    public SocialNetworkAPIApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
        CreateMap<Post, PostFullInfoDto>();
        CreateMap<CreatePhotoDto, Photo>()
            .ForMember(dest => dest.Id, otp => otp.Ignore())
            .ForMember(dest => dest.Status, otp => otp.Ignore())
            .ForMember(dest => dest.IsDeleted, otp => otp.Ignore());
        CreateMap<CreateCommentDto, Comment>()
            .ForMember(dest => dest.Id, otp => otp.Ignore())
            .ForMember(dest => dest.Status, otp => otp.Ignore())
            .ForMember(dest => dest.IsDeleted, otp => otp.Ignore());
    }
}