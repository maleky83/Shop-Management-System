
using ShopManagementSystem.Domain.Entities.Identity;

public class Role : BaseEntity
{
    public string Name { get; set; } = string.Empty;

    public ICollection<User> Users { get; set; } = new List<User>();

    public ICollection<RolePermission> RolePermissions { get; set; }
        = new List<RolePermission>();
}