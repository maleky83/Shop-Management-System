namespace ShopManagementSystem.Application.DTOs.Cart;

public record CartDto
{
    public int CartId { get; init; }
    public int UserId { get; init; }
    public List<CartItemDto> CartItems { get; init; } = [];
    public decimal TotalPrice { get; init; }
}
