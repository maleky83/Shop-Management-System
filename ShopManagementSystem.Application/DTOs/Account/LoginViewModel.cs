using System.ComponentModel.DataAnnotations;

namespace ShopManagementSystem.Application.DTOs.AccountViweModels
{
    public class LoginViewModel
    {
        [Required]
        [MaxLength(300)]
        public string Name { get; set; }
        [Required]
        [MaxLength(50)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
