namespace ShopManagementSystem.Application.DTOs.Admin
{
    public class UserViewModel
    {
        public int? UserId { get; set; }
        public int RoleId { get; set; }
        public required string PasswordHash { get; set; }
        public required string Name { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
