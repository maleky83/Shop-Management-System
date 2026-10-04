using ShopManagementSystem.Domain.Entities.Catalog;

namespace ShopManagementSystem.Domain.Entities.Carts;

public sealed class CartItem
{
    public Guid Id { get; set; } = Guid.Empty;
    public DateTime CreatedAt { get; set; }
    public required Guid CartId { get; set; }

    public Cart Cart { get; set; } = null!;

    public required Guid ProductId { get; set; }

    public Product Product { get; set; } = null!;

    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
}
