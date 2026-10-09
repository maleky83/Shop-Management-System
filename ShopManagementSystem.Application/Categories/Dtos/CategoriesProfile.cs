using AutoMapper;
using ShopManagementSystem.Domain.Entities.Catalog;

namespace ShopManagementSystem.Application.Categories.Dtos;

public class CategoriesProfile : Profile
{
    public CategoriesProfile()
    {
        CreateMap<Category, CategoryDto>()
            .ForMember(
                dest => dest.CategoryId,
                opt => opt.MapFrom(src => src.Id)
            );
    }
}
