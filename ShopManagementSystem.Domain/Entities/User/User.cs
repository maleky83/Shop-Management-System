namespace ShopManagementSystem.Domain.Entities.User;

public class User : BaseEntity
{
    public string Name { get; set; } = string.Empty;

    public string PasswordHash { get; set; } = string.Empty;

    public bool IsActive { get; set; } = true;

    #region Relations

    public int RoleId { get; set; }
    public Role Role { get; set; }

    public Cart? Cart { get; set; }

    public ICollection<Order> Orders { get; set; }
        = new List<Order>();

    #endregion
}