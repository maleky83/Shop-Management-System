using AutoMapper;
using ShopManagementSystem.Application.Carts.Dtos;
using ShopManagementSystem.Application.Interfaces.Shopping;
using ShopManagementSystem.Domain.Entities.Carts;
using ShopManagementSystem.Domain.Repositories.Shopping;

namespace ShopManagementSystem.Application.Carts;

public sealed class CartService(
    ICartRepository cartRepository,
    IMapper mapper
    ) : ICartService
{
    public async Task<CartDto> GetAsync(Guid userId)
    {

        Cart cart = await cartRepository.GetByUserIdAsync(userId);

        IEnumerable<CartItemDto> cartItems = mapper.Map<IEnumerable<CartItemDto>>(cart.CartItems);

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
