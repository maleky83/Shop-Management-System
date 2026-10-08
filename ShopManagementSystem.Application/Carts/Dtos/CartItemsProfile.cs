using AutoMapper;
using ShopManagementSystem.Domain.Entities.Carts;

namespace ShopManagementSystem.Application.Carts.Dtos;

public class CartItemsProfile : Profile
{
    public CartItemsProfile()
    {
        CreateMap<AddCartiItemDto, CartItem>();
    }
}
