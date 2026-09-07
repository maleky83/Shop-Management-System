using System.ComponentModel.DataAnnotations;

namespace ShopManagementSystem.Application.DTOs.Account;

public class LoginViewModel
{
    [Required]
    [MaxLength(300)]
    public required string Name { get; set; }
    [Required]
    [MaxLength(50)]
    [DataType(DataType.Password)]
    public required string Password { get; set; }
}
