using AutoMapper;
using MyShop.Application.Requests.Commands.Authentication;
using MyShop.Domain.Entities.Identity;

namespace MyShop.Application.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<ApplicationUser, SignUpRequest>().ReverseMap()
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email));
    }
}