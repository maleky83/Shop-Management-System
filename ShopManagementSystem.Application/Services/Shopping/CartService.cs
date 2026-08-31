using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ShopManagementSystem.Application.DTOs.Cart;
using ShopManagementSystem.Application.Exceptions;
using ShopManagementSystem.Application.Interfaces.Shopping;
using ShopManagementSystem.Domain.Entities.Carts;
using ShopManagementSystem.Domain.Entities.Catalog;
using ShopManagementSystem.Infrastructure.Data.Context;

namespace ShopManagementSystem.Application.Services.Shopping
{
    internal class CartService : ICartService
    {
        private readonly ApplicationDbContext _context;
        public CartService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
        }

        public async Task AddItemAsync(int userId, AddCartiItemViewModel model)
        {
            if (model.Quantity <= 0)
            {
                throw new BadRequestException("Quantity must be greater than 0");
            }

            Product? product = await _context.Products.FirstOrDefaultAsync(p => p.Id == model.ProductId);

            if (product == null)
            {
                throw new NotFoundException("Product not found");
            }

            Cart? cart = await _context.Carts
                .Include(c => c.CartItems)
                .FirstOrDefaultAsync(c => c.UserId == userId);

            if (cart == null)
            {
                cart = new Cart
                {
                    UserId = userId
                };

                await _context.Carts.AddAsync(cart);
                await _context.SaveChangesAsync();
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
            await _context.SaveChangesAsync();
        }

        public async Task<CartViewModel> GetAsync(int userId)
        {
            Cart? cart = await _context.Carts
                .Include(c => c.CartItems)
                .ThenInclude(c => c.Product)
                .FirstOrDefaultAsync(c => c.UserId == userId);

            if (cart == null)
            {
                throw new NotFoundException("Cart not found");
            }

            var result = new CartViewModel
            {
                CartId = cart.Id,
                UserId = userId,
                CartItems = cart.CartItems.Select(item => new CartItemViewModel
                {
                    CartItemId = item.Id,
                    ProductName = item.Product.Name,
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    UnitPrice = item.UnitPrice,
                    TotalPrice = item.UnitPrice * item.Quantity
                }).ToList()
            };

            result.TotalPrice = result.CartItems.Sum(ci => ci.TotalPrice);

            return result;

        }

        public async Task DeleteAsync(int userId)
        {
            Cart? cart = await _context.Carts.FirstOrDefaultAsync(c => c.UserId == userId);
            if (cart == null)
            {
                throw new NotFoundException("Cart not found");
            }
            _context.Carts.Remove(cart);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteItemAsync(int userId, int cartItemId)
        {
            CartItem? cartItem = await _context.CartItems
                .Include(c => c.Cart)
                .FirstOrDefaultAsync(c => c.Id == cartItemId && c.Cart.UserId == userId);

            if (cartItem == null)
            {
                throw new NotFoundException("Cart item not found");
            }

            _context.CartItems.Remove(cartItem);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateItemAsync(int userId, int cartItemId, UpdateCartItemViewModel model)
        {
            CartItem? cartItem = await _context.CartItems
                .Include(c => c.Cart)
                .FirstOrDefaultAsync(ci => ci.Cart.UserId == userId && ci.Id == cartItemId);

            if (cartItem == null)
            {
                throw new NotFoundException("Cart item not found");
            }

            cartItem.Quantity = model.Quantity;
            await _context.SaveChangesAsync();
        }
    }
}
