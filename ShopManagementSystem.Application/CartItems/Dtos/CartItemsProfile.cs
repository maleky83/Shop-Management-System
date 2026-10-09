using AutoMapper;
using ShopManagementSystem.Application.CartItems.Commands.CreateCartItem;
using ShopManagementSystem.Domain.Entities.Carts;

namespace ShopManagementSystem.Application.CartItems.Dtos;

public class CartItemsProfile : Profile
{
    public CartItemsProfile()
    {
        CreateMap<CreateCartItemCommand, CartItem>();
    }
}
