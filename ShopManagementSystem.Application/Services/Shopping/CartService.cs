using Microsoft.EntityFrameworkCore;
using ShopManagementSystem.Application.DTOs.Cart;
using ShopManagementSystem.Application.Exceptions;
using ShopManagementSystem.Application.Interfaces.Shopping;
using ShopManagementSystem.Application.Mappings.Shopping;
using ShopManagementSystem.Domain.Entities.Carts;
using ShopManagementSystem.Infrastructure.Data.Context;

namespace ShopManagementSystem.Application.Services.Shopping;

internal sealed class CartService(ApplicationDbContext dbContext) : ICartService
{
    public async Task<CartDto> GetAsync(string userId)
    {
        Cart? cart = await dbContext.Carts
            .Include(c => c.CartItems)
            .ThenInclude(c => c.Product)
            .FirstOrDefaultAsync(c => c.UserId == userId);

        if (cart == null)
        {
            throw new NotFoundException("Cart not found");
        }

        List<CartItemDto> cartItems = await dbContext
            .CartItems
            .Where(ci => ci.CartId == cart.Id)
            .Select(CartQueries.ProjectToDto()).ToListAsync();

        return new CartDto
        {
            CartId = cart.Id,
            UserId = userId,
            CartItems = cartItems,
            TotalPrice = cartItems.Sum(item => item.TotalPrice)
        };
    }

    public async Task DeleteAsync(string userId)
    {
        Cart? cart = await dbContext.Carts.FirstOrDefaultAsync(c => c.UserId == userId);
        if (cart == null)
        {
            throw new NotFoundException("Cart not found");
        }
        dbContext.Carts.Remove(cart);
        await dbContext.SaveChangesAsync();
    }
}
