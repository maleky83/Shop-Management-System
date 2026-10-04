using ShopManagementSystem.Domain.Entities.Catalog;

namespace ShopManagementSystem.Domain.Entities.Orders;

public sealed class OrderDetail
{
    public Guid Id { get; set; } = Guid.Empty;
    public DateTime CreatedAt { get; set; }
    public Guid OrderId { get; set; } = Guid.Empty;

    public Order Order { get; set; } = null!;

    public required Guid ProductId { get; set; }

    public Product Product { get; set; } = null!;

    public int Quantity { get; set; }

    public decimal UnitPrice { get; set; }
    public decimal TotalPrice { get; set; }
}
