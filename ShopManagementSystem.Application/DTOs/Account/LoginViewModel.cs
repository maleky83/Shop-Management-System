using System.ComponentModel.DataAnnotations;

namespace ShopManagementSystem.Application.DTOs.Account;

public record LoginViewModel
{
    [Required]
    [MaxLength(300)]
    public required string Name { get; init; }
    [Required]
    [MaxLength(50)]
    [DataType(DataType.Password)]
    public required string Password { get; init; }
}
