namespace ShopManagementSystem.Domain.Entities;

public class CategoryToProduct
{
    public int CategoryId { get; set; }

    public Category Category { get; set; } = null!;

    public int ProductId { get; set; }

    public Product Product { get; set; } = null!;
}