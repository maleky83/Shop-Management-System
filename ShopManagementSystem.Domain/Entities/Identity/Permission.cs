namespace ShopManagementSystem.Domain.Entities.Identity;

public sealed class Permission
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public DateTime CreatedAt { get; set; }

    public ICollection<RolePermission> RolePermissions { get; }
        = new List<RolePermission>();
}
