namespace ShopManagementSystem.Application.DTOs.Users
{
    public class UserDetailViewModel
    {
        public int? UserId { get; set; }
        public string? Name { get; set; }
        public string? Password { get; set; }
        public bool IsActive { get; set; }
    }
}
