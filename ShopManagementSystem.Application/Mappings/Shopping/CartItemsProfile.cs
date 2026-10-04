using AutoMapper;
using ShopManagementSystem.Application.DTOs.Cart;
using ShopManagementSystem.Domain.Entities.Carts;

namespace ShopManagementSystem.Application.Mappings.Shopping;

public class CartItemsProfile : Profile
{
    public CartItemsProfile()
    {
        CreateMap<AddCartiItemDto, CartItem>();
    }
}
