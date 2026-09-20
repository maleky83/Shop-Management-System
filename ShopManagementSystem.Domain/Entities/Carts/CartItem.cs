using ShopManagementSystem.Domain.Entities.Catalog;

namespace ShopManagementSystem.Domain.Entities.Carts;

public sealed class CartItem
{
    public string Id { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public required string CartId { get; set; }

    public Cart Cart { get; set; } = null!;

    public required string ProductId { get; set; }

    public Product Product { get; set; } = null!;

    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
}
