using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ShopManagementSystem.Application.DTOs.Cart;
using ShopManagementSystem.Application.Exceptions;
using ShopManagementSystem.Application.Interfaces.Shopping;
using ShopManagementSystem.Domain.Entities.Carts;
using ShopManagementSystem.Infrastructure.Data.Context;

namespace ShopManagementSystem.Application.Services.Shopping
{
    internal class CartService : ICartService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public CartService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task AddItemAsync(int userId, AddCartiItemViewModel model)
        {
            var cart = await _context.Carts
                .Include(c => c.CartItems)
                .FirstOrDefaultAsync(c => c.UserId == userId);

            if (cart is null)
            {
                cart = new Cart
                {
                    UserId = userId
                };

                await _context.Carts.AddAsync(cart);
                await _context.SaveChangesAsync();
            }

            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == model.ProductId);

            if (product is null)
            {
                throw new NotFoundException("Product not found");
            }

            var cartItem = await _context.CartItems
                .FirstOrDefaultAsync(ci => ci.ProductId == model.ProductId);

            if (cartItem is not null)
            {
                cartItem.Quantity += model.Quantity;
            }
            else
            {
                var newCartItem = _mapper.Map<CartItem>(model);

                newCartItem.UnitPrice = product.Price;

                cart.CartItems.Add(newCartItem);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<CartViewModel> GetAsync(int userId)
        {
            var cart = await _context.Carts
                .Include(c => c.CartItems)
                .ThenInclude(c => c.Product)
                .FirstOrDefaultAsync(c => c.UserId == userId);

            if (cart is null)
            {
                throw new NotFoundException("Cart not found");
            }

            var result = new CartViewModel
            {
                Id = cart.Id,
                UserId = userId,
                CartItems = cart.CartItems.Select(item => new CartItemViewModel
                {
                    Id = item.Id,
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
            var cart = await _context.Carts.FirstOrDefaultAsync(c => c.UserId == userId);
            if (cart is null)
            {
                throw new NotFoundException("Cart not found");
            }
            _context.Carts.Remove(cart);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteItemAsync(int userId, int cartItemId)
        {
            var cartItem = await _context.CartItems
                .Include(c => c.Cart)
                .FirstOrDefaultAsync(c => c.Id == cartItemId && c.Cart.UserId == userId);

            if (cartItem is null)
            {
                throw new NotFoundException("Cart item not found");
            }

            _context.CartItems.Remove(cartItem);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateItemAsync(int userId, int cartItemId, UpdateCartItemViewModel model)
        {
            var cartItem = await _context.CartItems
                .Include(c => c.Cart)
                .FirstOrDefaultAsync(ci => ci.Cart.UserId == userId && ci.Id == cartItemId);

            if (cartItem is null)
            {
                throw new NotFoundException("Cart item not found");
            }

            cartItem.Quantity = model.Quantity;
            await _context.SaveChangesAsync();
        }
    }
}
