namespace ShopManagementSystem.Application.DTOs.Admin
{
    public class UpdateUserViewModel
    {
        public required string Name { get; set; }
        public string? NewPassword { get; set; }
        public int RoleId { get; set; }
        public bool IsActive { get; set; }
    }
}
