using AutoMapper;
using ShopManagementSystem.Application.Products.Commands.CreateProduct;
using ShopManagementSystem.Application.Products.Commands.UpdateProduct;
using ShopManagementSystem.Domain.Entities.Catalog;

namespace ShopManagementSystem.Application.Products.Dtos;

public class ProductsProfile : Profile
{
    public ProductsProfile()
    {

        CreateMap<UpdateProductCommand, Product>();

        CreateMap<CreateProductCommand, Product>();

        CreateMap<Product, ProductDto>()
            .ForMember(
                dest => dest.ProductId,
                opt => opt.MapFrom(src => src.Id)
            );

        CreateMap<CreateProductCommand, Product>();
    }
}
