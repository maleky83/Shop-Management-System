using ShopManagementSystem.Domain.Entities.Carts;

namespace ShopManagementSystem.Domain.Entities.Identity;

public class User : BaseEntity
{
    public string Name { get; set; } = string.Empty;

    public string PasswordHash { get; set; } = string.Empty;

    public bool IsActive { get; set; } = true;

    #region Relations

    public int RoleId { get; set; }
    public Role Role { get; set; }

    public Cart? Cart { get; set; }

    public ICollection<Orders.Order> Orders { get; set; }
        = new List<Orders.Order>();

    #endregion
}