using AutoMapper;
using ShopManagementSystem.Application.DTOs.AccountViweModels;
using ShopManagementSystem.Application.DTOs.Admin;
using ShopManagementSystem.Domain.Entities.User;

namespace ShopManagementSystem.Application.Mappers
{
    public class UsertProfile : Profile
    {
        public UsertProfile()
        {
            CreateMap<User, UserViewModel>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Id));

            CreateMap<User, UpdateUserViewModel>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.NewPassword, opt => opt.Ignore());

            CreateMap<CreateUserViewModel, User>();

            CreateMap<RegisterViewModel, User>()
                .ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(src => src.Password));

        }
    }
}
