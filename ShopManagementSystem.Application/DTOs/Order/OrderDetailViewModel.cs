namespace ShopManagementSystem.Application.DTOs.Order;

public class OrderDetailViewModel
{
    public int OrderDetailId { get; set; }
    public int OrderId { get; set; }
    public int ProductId { get; set; }
    public decimal UnitPrice { get; set; }
    public int Quantity { get; set; }
}
