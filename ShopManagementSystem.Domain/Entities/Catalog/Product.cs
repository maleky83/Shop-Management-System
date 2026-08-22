using ShopManagementSystem.Domain.Entities.Carts;
using ShopManagementSystem.Domain.Entities.Orders;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopManagementSystem.Domain.Entities.Catalog;

public class Product : BaseEntity
{
    public string? Name { get; set; } = string.Empty;

    public string? Description { get; set; }

    public string? PictureName { get; set; }

    public decimal Price { get; set; }

    public int Quantity { get; set; }

    public bool IsActive { get; set; } = true;


    #region Relations

    public int CategoryId { get; set; }
    [ForeignKey(nameof(CategoryId))]
    public Category Category { get; set; } = null!;

    public ICollection<OrderDetail> OrderDetails { get; set; }
        = new List<OrderDetail>();

    public ICollection<CartItem> CartItems { get; set; }
        = new List<CartItem>();

    #endregion
}