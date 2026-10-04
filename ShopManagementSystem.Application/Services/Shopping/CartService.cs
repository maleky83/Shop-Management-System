using AutoMapper;
using ShopManagementSystem.Application.DTOs.Cart;
using ShopManagementSystem.Application.Interfaces.Shopping;
using ShopManagementSystem.Domain.Repositories.Shopping;

namespace ShopManagementSystem.Application.Services.Shopping;

public sealed class CartService(
    ICartRepository cartRepository,
    IMapper mapper
    ) : ICartService
{
    public async Task<CartDto> GetAsync(Guid userId)
    {

        var cart = await cartRepository.GetAsync(userId);

        var cartItems = mapper.Map<IEnumerable<CartItemDto>>(cart.CartItems);

        return new CartDto
        {
            CartId = cart.Id,
            UserId = userId,
            CartItems = cartItems,
            TotalPrice = cartItems.Sum(item => item.TotalPrice)
        };
    }

    public async Task DeleteAsync(Guid userId)
    {
        await cartRepository.DeleteAsync(userId);
    }
}
