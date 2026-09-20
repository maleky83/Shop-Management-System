using ShopManagementSystem.Domain.Entities.Carts;

namespace ShopManagementSystem.Domain.Entities.Identity;

public sealed class User
{
    public string Id { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public required string Name { get; set; }

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
