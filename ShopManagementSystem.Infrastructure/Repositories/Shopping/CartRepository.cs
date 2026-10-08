using Microsoft.EntityFrameworkCore;
using ShopManagementSystem.Application.Exceptions;
using ShopManagementSystem.Domain.Entities.Carts;
using ShopManagementSystem.Domain.Repositories.Shopping;
using ShopManagementSystem.Infrastructure.Persistence;

namespace ShopManagementSystem.Infrastructure.Repositories.Shopping;

internal class CartRepository(ApplicationDbContext dbContext) : ICartRepository
{
    public async Task<Cart> GetByUserIdAsync(Guid userId)
    {
        Cart? cart = await dbContext.Carts
         .Include(c => c.CartItems)
         .ThenInclude(c => c.Product)
         .FirstOrDefaultAsync(c => c.UserId == userId);

        if (cart == null)
        {
            throw new NotFoundException("Cart not found");
        }

        return cart;
    }

    public async Task DeleteAsync(Guid userId)
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
