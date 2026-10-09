using ShopManagementSystem.Application.CartItems.Dtos;

namespace ShopManagementSystem.Application.Carts.Dtos;

public class CartDto
{
    public Guid CartId { get; set; } = default!;
    public Guid UserId { get; set; } = default!;
    public IEnumerable<CartItemDto> CartItems { get; set; } = default!;
    public decimal TotalPrice { get; set; }
}
