namespace ShopManagementSystem.Application.DTOs.Cart;

public record CartDto
{
    public required string CartId { get; init; }
    public required string UserId { get; init; }
    public List<CartItemDto> CartItems { get; init; } = [];
    public decimal TotalPrice { get; init; }
}
