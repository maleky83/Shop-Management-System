namespace ShopManagementSystem.Domain.Entities.Identity;

public sealed class Permission
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }

    public ICollection<RolePermission> RolePermissions { get; }
        = new List<RolePermission>();
}
