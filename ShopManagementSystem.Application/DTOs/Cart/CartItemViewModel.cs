namespace ShopManagementSystem.Application.DTOs.Cart;

public class CartItemViewModel
{
    public int CartItemId { get; set; }
    public decimal TotalPrice { get; set; }
    public int ProductId { get; set; }
    public string? ProductName { get; set; }
    public decimal UnitPrice { get; set; }
    public int Quantity { get; set; }
}
