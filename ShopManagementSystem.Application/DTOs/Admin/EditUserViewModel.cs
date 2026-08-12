namespace ShopManagementSystem.Application.DTOs.Admin
{
    public class EditUserViewModel
    {
        public int? UserId { get; set; }
        public string? Name { get; set; }
        public string? NewPassword { get; set; }
        public bool IsAdmin { get; set; }
    }
}
