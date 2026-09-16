using Microsoft.EntityFrameworkCore;
using ShopManagementSystem.Application.DTOs.Cart;
using ShopManagementSystem.Application.Exceptions;
using ShopManagementSystem.Application.Interfaces.Shopping;
using ShopManagementSystem.Application.Mappings;
using ShopManagementSystem.Domain.Entities.Carts;
using ShopManagementSystem.Domain.Entities.Catalog;
using ShopManagementSystem.Infrastructure.Data.Context;

namespace ShopManagementSystem.Application.Services.Shopping;

internal class CartService(ApplicationDbContext context) : ICartService
{
    public async Task AddItemAsync(string userId, AddCartiItemDto model)
    {
        if (model.Quantity <= 0)
        {
            throw new BadRequestException("Quantity must be greater than 0");
        }

        Product? product = await context.Products.FirstOrDefaultAsync(p => p.Id == model.ProductId);

        if (product == null)
        {
            throw new NotFoundException("Product not found");
        }

        Cart? cart = await context.Carts
            .Include(c => c.CartItems)
            .FirstOrDefaultAsync(c => c.UserId == userId);

        if (cart == null)
        {
            cart = new Cart
            {
                UserId = userId
            };

            await context.Carts.AddAsync(cart);
            await context.SaveChangesAsync();
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
        await context.SaveChangesAsync();
    }

    public async Task<CartDto> GetAsync(string userId)
    {
        Cart? cart = await context.Carts
            .Include(c => c.CartItems)
            .ThenInclude(c => c.Product)
            .FirstOrDefaultAsync(c => c.UserId == userId);

        if (cart == null)
        {
            throw new NotFoundException("Cart not found");
        }

        List<CartItemDto> cartItems = await context
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
        Cart? cart = await context.Carts.FirstOrDefaultAsync(c => c.UserId == userId);
        if (cart == null)
        {
            throw new NotFoundException("Cart not found");
        }
        context.Carts.Remove(cart);
        await context.SaveChangesAsync();
    }

    public async Task DeleteItemAsync(string userId, string cartItemId)
    {
        CartItem? cartItem = await context.CartItems
            .Include(c => c.Cart)
            .FirstOrDefaultAsync(c => c.Id == cartItemId && c.Cart.UserId == userId);

        if (cartItem == null)
        {
            throw new NotFoundException("Cart item not found");
        }

        context.CartItems.Remove(cartItem);
        await context.SaveChangesAsync();
    }

    public async Task UpdateItemAsync(string userId, string cartItemId, UpdateCartItemDto model)
    {
        CartItem? cartItem = await context.CartItems
            .Include(c => c.Cart)
            .FirstOrDefaultAsync(ci => ci.Cart.UserId == userId && ci.Id == cartItemId);

        if (cartItem == null)
        {
            throw new NotFoundException("Cart item not found");
        }

        cartItem.Quantity = model.Quantity;
        await context.SaveChangesAsync();
    }
}
