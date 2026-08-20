namespace ShopManagementSystem.Application.DTOs.Admin
{
    public class UserViewModel
    {
        public int? UserId { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public DateTime RegisterDate { get; set; }
    }
}
