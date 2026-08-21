using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ShopManagementSystem.Application.DTOs.Account
{
    public class RegisterViewModel
    {
        [MaxLength(300)]
        [Required]
        [Remote("VerifyName", "Account")]
        public required string Name { get; set; }
        [MaxLength(50)]
        [DataType(DataType.Password)]
        [Required]
        public required string Password { get; set; }
        [MaxLength(50)]
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        [Required]
        public required string RePassword { get; set; }
    }
}
