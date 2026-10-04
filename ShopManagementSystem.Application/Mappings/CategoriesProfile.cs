using AutoMapper;
using ShopManagementSystem.Application.DTOs.Category;
using ShopManagementSystem.Domain.Entities.Catalog;

namespace ShopManagementSystem.Application.Mappings;

public class CategoriesProfile : Profile
{
    public CategoriesProfile()
    {
        CreateMap<CreateCategoryDto, Category>();
        CreateMap<Category, CategoryDto>();
    }
}
