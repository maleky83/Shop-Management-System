using AutoMapper;
using ShopManagementSystem.Application.DTOs.Account;
using ShopManagementSystem.Application.DTOs.Users;
using ShopManagementSystem.Domain.Entities.Identity;

namespace ShopManagementSystem.Application.Mappings;

public class UsertProfile : Profile
{
    public UsertProfile()
    {
        CreateMap<User, UserDto>()
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Id));

        CreateMap<User, UpdateUserDto>()
            .ForMember(dest => dest.NewPassword, opt => opt.Ignore());

        CreateMap<UpdateUserDto, User>();

        CreateMap<CreateUserDto, User>();

        CreateMap<RegisterDto, User>()
            .ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(src => src.Password));
    }
}
