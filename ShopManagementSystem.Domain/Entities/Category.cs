namespace ShopManagementSystem.Domain.Entities;

public class Category : BaseEntity
{
    public string Name { get; set; } = string.Empty;

    public string? Description { get; set; }

    public bool IsActive { get; set; } = true;

    #region Relations

    public ICollection<CategoryToProduct> CategoryToProducts { get; set; }
        = new List<CategoryToProduct>();

    #endregion
}