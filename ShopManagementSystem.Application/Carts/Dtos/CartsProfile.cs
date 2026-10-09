using AutoMapper;
using ShopManagementSystem.Domain.Entities.Carts;

namespace ShopManagementSystem.Application.Carts.Dtos;

public class CartsProfile : Profile
{
    public CartsProfile()
    {
        CreateMap<Cart, CartDto>()
            .ForMember(d => d.CartId, opt =>
            {
                opt.MapFrom(src => src.Id);
            }).ForMember(d => d.TotalPrice, opt =>
            {
                opt.MapFrom(src => src.CartItems.Sum(ci => ci.Price));
            });


    }
}
