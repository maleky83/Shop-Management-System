namespace ShopManagementSystem.Domain.Entities.Identity;

public sealed class Role : BaseEntity
{
    public string Name { get; set; } = string.Empty;

    public ICollection<User> Users { get; } = new List<User>();

    public ICollection<RolePermission> RolePermissions { get; }
        = new List<RolePermission>();
}
