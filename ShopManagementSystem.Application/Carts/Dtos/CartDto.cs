namespace ShopManagementSystem.Application.Carts.Dtos;

public record CartDto
{
    public required Guid CartId { get; init; }
    public required Guid UserId { get; init; }
    public IEnumerable<CartItemDto> CartItems { get; init; } = [];
    public decimal TotalPrice { get; init; }
}
