using ShopManagementSystem.Application.Carts.Dtos;

namespace ShopManagementSystem.Application.Interfaces.Shopping;

public interface ICartService
{
    Task DeleteAsync(Guid userId);
    Task<CartDto> GetAsync(Guid userId);
}
