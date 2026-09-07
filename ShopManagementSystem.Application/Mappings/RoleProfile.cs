using AutoMapper;
using ShopManagementSystem.Application.DTOs;
using ShopManagementSystem.Domain.Entities.Identity;

namespace ShopManagementSystem.Application.Mappings;

public class RoleProfile : Profile
{
    public RoleProfile()
    {
        CreateMap<Role, RoleViewModel>()
            .ForMember(dest => dest.RoleId, opt => opt.MapFrom(src => src.Id));
    }
}
