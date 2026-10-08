using AutoMapper;
using ShopManagementSystem.Application.Carts.Dtos;
using ShopManagementSystem.Application.Interfaces.Shopping;
using ShopManagementSystem.Domain.Entities.Carts;
using ShopManagementSystem.Domain.Repositories.Shopping;

namespace ShopManagementSystem.Application.Carts;

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
        CartItem cartItem = mapper.Map<CartItem>(addCartItemDto);

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
        CartItem cartItem = mapper.Map<CartItem>(updateCartItemDto);

        await cartItemRepository.UpdateAsync(userId, cartItemId, cartItem);
    }
}
