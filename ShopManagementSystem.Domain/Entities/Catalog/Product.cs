using System.ComponentModel.DataAnnotations.Schema;
using ShopManagementSystem.Domain.Entities.Carts;
using ShopManagementSystem.Domain.Entities.Orders;

namespace ShopManagementSystem.Domain.Entities.Catalog;

public sealed class Product
{
    public string Id { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public required string Name { get; set; }

    public string? Description { get; set; }

    public string? PictureName { get; set; }

    public decimal Price { get; set; }

    public int Quantity { get; set; }

    public bool IsActive { get; set; } = true;
    public required string CategoryId { get; set; }


    #region Relations

    [ForeignKey(nameof(CategoryId))]
    public Category Category { get; set; } = null!;

    public ICollection<OrderDetail> OrderDetails { get; }
        = new List<OrderDetail>();

    public ICollection<CartItem> CartItems { get; }
        = new List<CartItem>();

    #endregion
}
