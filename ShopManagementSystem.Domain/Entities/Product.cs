namespace ShopManagementSystem.Domain.Entities;

public class Product : BaseEntity
{
    public string Name { get; set; } = string.Empty;

    public string? Description { get; set; }

    public string? PictureName { get; set; }

    public decimal Price { get; set; }

    public int QuantityInStock { get; set; }

    public bool IsActive { get; set; } = true;

    #region Relations

    public ICollection<CategoryToProduct> CategoryToProducts { get; set; }
        = new List<CategoryToProduct>();

    public ICollection<OrderDetail> OrderDetails { get; set; }
        = new List<OrderDetail>();

    public ICollection<CartItem> CartItems { get; set; }
        = new List<CartItem>();

    #endregion
}