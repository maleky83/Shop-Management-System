using AutoMapper;
using ShopManagementSystem.Application.DTOs.Category;
using ShopManagementSystem.Domain.Entities.Catalog;

namespace ShopManagementSystem.Application.Mappings
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryViewModel>()
                .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.Id));

            CreateMap<CreateCategoryViewModel, Category>();

            CreateMap<UpdateCategoryViewModel, Category>();
        }
    }
}
