using ShopManagementSystem.Domain.Entities.Catalog;

namespace ShopManagementSystem.Domain.Entities.Orders;

public sealed class OrderDetail : BaseEntity
{
    public string OrderId { get; set; } = string.Empty;

    public Order Order { get; set; } = null!;

    public required string ProductId { get; set; }

    public Product Product { get; set; } = null!;

    public int Quantity { get; set; }

    public decimal UnitPrice { get; set; }
    public decimal TotalPrice { get; set; }
}
