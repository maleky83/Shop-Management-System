using System.ComponentModel.DataAnnotations;

namespace Program.Data.Entities
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        [MaxLength(300)]
        public string Name { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public DateTime RegisterDate { get; set; }
        public bool IsAdmin { get; set; }

        public List<Order> Orders { get; set; }
    }
}
