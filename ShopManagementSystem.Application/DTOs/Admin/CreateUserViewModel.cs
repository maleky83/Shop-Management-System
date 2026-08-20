using System.ComponentModel.DataAnnotations;

namespace ShopManagementSystem.Application.DTOs.Admin
{
    public class CreateUserViewModel
    {
        [Required]
        public required string Name { get; set; }
        [Required]
        public required string Password { get; set; }
        public bool IsActive { get; set; }
        public required int RoleId { get; set; }

    }
}
