using AutoMapper;
using ShopManagementSystem.Application.DTOs.Product;
using ShopManagementSystem.Application.DTOs.ProductViewModels;
using ShopManagementSystem.Domain.Entities;

namespace ShopManagementSystem.Application.Mappers
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductViewModel>()
                .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.Id));

            CreateMap<ProductViewModel, UpdateProductViewModel>();

            CreateMap<Product, UpdateProductViewModel>()
                .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.Id));

            CreateMap<CreateProductViewModel, Product>();
        }
    }
}
