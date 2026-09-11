namespace ShopManagementSystem.Application.DTOs.Cart;

public record CartViewModel
{
    public int CartId { get; init; }
    public int UserId { get; init; }
    public List<CartItemViewModel> CartItems { get; init; } = [];
    public decimal TotalPrice { get; init; }
}
