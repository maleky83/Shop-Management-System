using System.ComponentModel.DataAnnotations;

namespace ShopManagementSystem.Application.DTOs.Admin
{
    public class CreateUserViewModel
    {
        [Required] 
        public string Name { get; set; }
        [Required]
        public string Password { get; set; }
        public bool IsAdmin { get; set; }

    }
}
