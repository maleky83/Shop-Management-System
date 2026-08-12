using System.ComponentModel.DataAnnotations;

namespace ShopManagementSystem.Application.DTOs.Account
{
    public class UserDetailViewModel
    {
        public int UserId { get; set; }
        [Required]
        [MaxLength(300)]
        public string Name { get; set; }
        [Required]
        [MaxLength(50)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
    }
}
