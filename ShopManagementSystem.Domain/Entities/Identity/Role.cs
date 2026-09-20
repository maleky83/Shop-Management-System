namespace ShopManagementSystem.Domain.Entities.Identity;

public sealed class Role
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public DateTime CreatedAt { get; set; }

    public ICollection<User> Users { get; } = new List<User>();

    public ICollection<RolePermission> RolePermissions { get; }
        = new List<RolePermission>();
}
