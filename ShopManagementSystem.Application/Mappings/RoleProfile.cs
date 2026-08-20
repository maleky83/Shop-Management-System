using AutoMapper;
using ShopManagementSystem.Application.DTOs;

namespace ShopManagementSystem.Application.Mappings
{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<Role, RoleViewModel>()
                .ForMember(dest => dest.RoleId, opt => opt.MapFrom(src => src.Id));
        }
    }
}
