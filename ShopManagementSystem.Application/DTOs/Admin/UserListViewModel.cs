namespace ShopManagementSystem.Application.DTOs.Admin
{
    public class UserListViewModel
    {
        public int? UserId { get; set; }
        public string Name { get; set; }
        public bool IsAdmin { get; set; }
        public DateTime RegisterDate { get; set; }
    }
}
