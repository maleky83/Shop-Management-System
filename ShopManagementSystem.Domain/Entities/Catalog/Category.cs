namespace ShopManagementSystem.Domain.Entities.Catalog;

public sealed class Category : BaseEntity
{
    public string Name { get; set; } = string.Empty;

    public string? Description { get; set; }

    public bool IsActive { get; set; } = true;

    #region Relations

    public ICollection<Product> Products { get; } = new List<Product>();

    #endregion
}
