using AutoMapper;
using ShopManagementSystem.Application.DTOs.Cart;
using ShopManagementSystem.Domain.Entities.Carts;

namespace ShopManagementSystem.Application.Mappings;

public class CartProfile : Profile
{
    public CartProfile()
    {
        CreateMap<Cart, CartViewModel>();

        CreateMap<AddCartiItemViewModel, CartItem>()
            .ForMember(dest => dest.UnitPrice, opt => opt.Ignore());
    }
}
