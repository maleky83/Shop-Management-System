using ShopManagementSystem.Domain.Entities.Carts;

namespace ShopManagementSystem.Domain.Entities.Identity;

public sealed class User : BaseEntity
{
    public string Name { get; set; } = string.Empty;

    public string PasswordHash { get; set; } = string.Empty;

    public bool IsActive { get; set; } = true;

    #region Relations

    public int RoleId { get; set; }
    public Role Role { get; set; } = null!;

    public Cart? Cart { get; set; }

    public ICollection<Orders.Order> Orders { get; }
        = new List<Orders.Order>();

    #endregion
}
