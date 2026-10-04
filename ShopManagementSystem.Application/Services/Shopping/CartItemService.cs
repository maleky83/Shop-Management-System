using AutoMapper;
using ShopManagementSystem.Application.DTOs.Cart;
using ShopManagementSystem.Application.Interfaces.Shopping;
using ShopManagementSystem.Domain.Entities.Carts;
using ShopManagementSystem.Domain.Repositories.Shopping;

namespace ShopManagementSystem.Application.Services.Shopping;

public sealed class CartItemService(
    ICartItemRepository cartItemRepository,
    IMapper mapper
    ) : ICartItemService
{
    public async Task AddAsync(
        Guid userId,
        AddCartiItemDto addCartItemDto
        )
    {
        var cartItem = mapper.Map<CartItem>(addCartItemDto);

        await cartItemRepository.AddAsync(userId, cartItem);
    }

    public async Task DeleteAsync(Guid userId, Guid cartItemId)
    {
        await cartItemRepository.DeleteAsync(userId, cartItemId);
    }

    public async Task UpdateAsync(
        Guid userId,
        Guid cartItemId,
        UpdateCartItemDto updateCartItemDto)
    {
        var cartItem = mapper.Map<CartItem>(updateCartItemDto);

        await cartItemRepository.UpdateAsync(userId, cartItemId, cartItem);
    }
}
