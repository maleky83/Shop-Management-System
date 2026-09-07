namespace ShopManagementSystem.Domain.Entities.Identity;

public sealed class Permission : BaseEntity
{
    public string Name { get; set; } = string.Empty;

    public ICollection<RolePermission> RolePermissions { get; }
        = new List<RolePermission>();
}
