using AutoMapper;
using ShopManagementSystem.Application.DTOs.Product;
using ShopManagementSystem.Domain.Entities.Catalog;

namespace ShopManagementSystem.Application.Mappings;

public class ProductsProfile : Profile
{
    public ProductsProfile()
    {
        CreateMap<UpdateProductDto, Product>();
        CreateMap<CreateProductDto, Product>();
        CreateMap<Product, ProductDto>();
    }
}
