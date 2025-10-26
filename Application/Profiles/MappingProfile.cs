using AutoMapper;
using MyShop.Application.DTOs.Authentication;
using MyShop.Application.Requests.Commands.Authentication;
using MyShop.Domain.Entities.Identity;

namespace MyShop.Application.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<SignInRequest, SignUpRequestDto>().ReverseMap(); // todo: fix mapping
    }
}