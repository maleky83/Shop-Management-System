using Microsoft.EntityFrameworkCore;
using ShopManagementSystem.Application.Exceptions;
using ShopManagementSystem.Domain.Entities.Carts;
using ShopManagementSystem.Domain.Entities.Catalog;
using ShopManagementSystem.Domain.Repositories.Shopping;
using ShopManagementSystem.Infrastructure.Persistence;

namespace ShopManagementSystem.Infrastructure.Repositories.Shopping;

internal class CartItemRepository(ApplicationDbContext dbContext) : ICartItemRepository
{
    public async Task<IEnumerable<CartItem>> GetAllByCartIdAsync(Guid cartId)
    {
        var cartItems = await dbContext
            .CartItems
            .Where(ci => ci.CartId == cartId)
            .ToListAsync();

        return cartItems;
    }

    public async Task AddAsync(Guid userId, CartItem entity)
    {
        Product? product = await dbContext.Products.FirstOrDefaultAsync(p => p.Id == entity.ProductId);

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
            .FirstOrDefault(ci => ci.ProductId == entity.ProductId);

        if (cartItem != null)
        {
            cartItem.Quantity += entity.Quantity;
        }

        else
        {
            cartItem = new CartItem
            {
                Quantity = entity.Quantity,
                ProductId = entity.ProductId,
                UnitPrice = product.Price,
                CartId = cart.Id,
            };

            cart.CartItems.Add(cartItem);
        }

        await dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid userId, Guid cartItemId)
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

    public async Task UpdateAsync(Guid userId, Guid cartItemId, CartItem dto)
    {
        CartItem? cartItem = await dbContext.CartItems
            .Include(c => c.Cart)
            .FirstOrDefaultAsync(ci => ci.Cart.UserId == userId && ci.Id == cartItemId);

        if (cartItem == null)
        {
            throw new NotFoundException("Cart item not found");
        }

        cartItem.Quantity = dto.Quantity;
        await dbContext.SaveChangesAsync();
    }
}
