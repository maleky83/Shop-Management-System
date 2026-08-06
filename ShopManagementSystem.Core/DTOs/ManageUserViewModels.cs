using System.ComponentModel.DataAnnotations;

namespace ShopManagementSystem.Core.DTOs
{
    public class EditUserViweModel
    {
        public int UserId { get; set; }
        [Required]
        [MaxLength(300)]
        public string Name { get; set; }
        [MaxLength(50)]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        public bool IsAdmin { get; set; }
    }
}
