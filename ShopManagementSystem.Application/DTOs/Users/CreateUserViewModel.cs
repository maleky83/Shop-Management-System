using System.ComponentModel.DataAnnotations;

namespace ShopManagementSystem.Application.DTOs.Users
{
    public class CreateUserViewModel
    {
        [Required]
        public required string Name { get; set; }
        [Required]
        public required string Password { get; set; }
        [Required]
        public required int RoleId { get; set; }

    }
}
