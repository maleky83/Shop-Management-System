using Microsoft.EntityFrameworkCore;
using ShopManagementSystem.Application.DTOs.Cart;
using ShopManagementSystem.Application.Exceptions;
using ShopManagementSystem.Application.Interfaces.Shopping;
using ShopManagementSystem.Domain.Entities.Carts;
using ShopManagementSystem.Domain.Entities.Catalog;
using ShopManagementSystem.Infrastructure.Data.Context;

namespace ShopManagementSystem.Application.Services.Shopping;

internal sealed class CartItemService(ApplicationDbContext dbContext) : ICartItemService
{
    public async Task AddAsync(string userId, AddCartiItemDto model)
    {
        if (model.Quantity <= 0)
        {
            throw new BadRequestException("Quantity must be greater than 0");
        }

        Product? product = await dbContext.Products.FirstOrDefaultAsync(p => p.Id == model.ProductId);

        if (product == null)
        {
            throw new NotFoundException("Product not found");
        }

        Cart? cart = await dbContext.Carts
            .Include(c => c.CartItems)
            .FirstOrDefaultAsync(c => c.UserId == userId);

        if (cart == null)
        {
            cart = new Cart
            {
                UserId = userId
            };

            await dbContext.Carts.AddAsync(cart);
            await dbContext.SaveChangesAsync();
        }

        CartItem? cartItem = cart.CartItems
            .FirstOrDefault(ci => ci.ProductId == model.ProductId);

        if (cartItem != null)
        {
            cartItem.Quantity += model.Quantity;
        }

        else
        {
            cartItem = new CartItem
            {
                Quantity = model.Quantity,
                ProductId = model.ProductId,
                UnitPrice = product.Price,
                CartId = cart.Id,
            };

            cart.CartItems.Add(cartItem);
        }

        await dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(string userId, string cartItemId)
    {
        CartItem? cartItem = await dbContext.CartItems
            .Include(c => c.Cart)
            .FirstOrDefaultAsync(c => c.Id == cartItemId && c.Cart.UserId == userId);

        if (cartItem == null)
        {
            throw new NotFoundException("Cart item not found");
        }

        dbContext.CartItems.Remove(cartItem);
        await dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(string userId, string cartItemId, UpdateCartItemDto model)
    {
        CartItem? cartItem = await dbContext.CartItems
            .Include(c => c.Cart)
            .FirstOrDefaultAsync(ci => ci.Cart.UserId == userId && ci.Id == cartItemId);

        if (cartItem == null)
        {
            throw new NotFoundException("Cart item not found");
        }

        cartItem.Quantity = model.Quantity;
        await dbContext.SaveChangesAsync();
    }
}
