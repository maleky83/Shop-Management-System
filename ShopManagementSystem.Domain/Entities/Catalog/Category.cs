namespace ShopManagementSystem.Domain.Entities.Catalog;

public sealed class Category
{
    public Guid Id { get; set; } = Guid.Empty;
    public DateTime CreatedAt { get; set; }
    public required string Name { get; set; }

    public string? Description { get; set; }

    public bool IsActive { get; set; } = true;

    #region Relations

    public ICollection<Product> Products { get; } = new List<Product>();

    #endregion
}
