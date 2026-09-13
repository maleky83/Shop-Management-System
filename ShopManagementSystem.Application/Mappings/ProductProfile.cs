using AutoMapper;
using ShopManagementSystem.Application.DTOs.Product;
using ShopManagementSystem.Domain.Entities.Catalog;

namespace ShopManagementSystem.Application.Mappings;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<Product, ProductDto>()
            .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.Id));

        CreateMap<ProductDto, UpdateProductDto>();

        CreateMap<Product, UpdateProductDto>();

        CreateMap<UpdateProductDto, Product>();

        CreateMap<CreateProductDto, Product>();
    }
}
