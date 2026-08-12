namespace ShopManagementSystem.Application.DTOs.Admin
{
    public class UserDetailViewModel
    {
        public int? UserId { get; set; }
        public string? Name { get; set; }
        public string? Password { get; set; }
        public bool IsAdmin { get; set; }
    }
}
