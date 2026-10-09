using ShopManagementSystem.Domain.Entities.Catalog;

namespace ShopManagementSystem.Domain.Entities.Carts;

public class CartItem
{
    public Guid Id { get; set; } = default!;
    public DateTime CreatedAt { get; set; }
    public Guid CartId { get; set; } = default!;

    public Cart Cart { get; set; } = null!;

    public Guid ProductId { get; set; } = default!;

    public Product Product { get; set; } = null!;

    public int Quantity { get; set; }
    public decimal Price { get; set; }
}
