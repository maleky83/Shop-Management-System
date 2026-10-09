using Microsoft.EntityFrameworkCore;
using ShopManagementSystem.Domain.Entities.Carts;
using ShopManagementSystem.Domain.Repositories.Shopping;
using ShopManagementSystem.Infrastructure.Persistence;

namespace ShopManagementSystem.Infrastructure.Repositories.Shopping;

internal class CartRepository(ApplicationDbContext dbContext) : ICartRepository
{
    public async Task<Cart?> GetByUserIdAsync(Guid userId)
    {
        Cart? cart = await dbContext.Carts
         .Include(c => c.CartItems)
         .ThenInclude(c => c.Product)
         .FirstOrDefaultAsync(c => c.UserId == userId);

        return cart;
    }

    public async Task DeleteAsync(Cart entity)
    {
        dbContext.Carts.Remove(entity);
        await dbContext.SaveChangesAsync();
    }

}
