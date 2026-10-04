using AutoMapper;
using ShopManagementSystem.Application.DTOs.Account;
using ShopManagementSystem.Application.DTOs.Users;
using ShopManagementSystem.Domain.Entities.Identity;

namespace ShopManagementSystem.Application.Mappings;

public class UsersProfile : Profile
{
    public UsersProfile()
    {
        CreateMap<User, UserDto>();

        CreateMap<UserDto, User>();

        CreateMap<CreateUserDto, User>();

        CreateMap<UpdateUserDto, User>();

        CreateMap<RegisterDto, User>();
    }
}
