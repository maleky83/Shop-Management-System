using AutoMapper;
using ShopManagementSystem.Application.DTOs.Users;
using ShopManagementSystem.Domain.Entities.Identity;

namespace ShopManagementSystem.Application.Users.Dtos;

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
