using Microsoft.AspNetCore.Mvc;
using ShopManagementSystem.Domain.Entities.Orders;
using System.ComponentModel.DataAnnotations;
using CompareAttribute = System.ComponentModel.DataAnnotations.CompareAttribute;

namespace ShopManagementSystem.Application.DTOs
{
    public class RegisterViewModel
    {
        [MaxLength(300)]
        [Required]
        [Remote("VerifyName", "Account")]
        public string Name { get; set; }
        [MaxLength(50)]
        [DataType(DataType.Password)]
        [Required]
        public required string Password { get; set; }
        [MaxLength(50)]
        [DataType(DataType.Password)]
        [Compare("Password")]
        [Required]
        public string RePassword { get; set; }

    }
    public class LoginViewModel
    {
        [Required]
        [MaxLength(300)]
        public string Name { get; set; }
        [Required]
        [MaxLength(50)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
    public class UserViewModel
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public DateTime RegisterDate { get; set; }
        public bool IsAdmin { get; set; }

        public ICollection<Order> Orders { get; set; } = [];
    }
}
