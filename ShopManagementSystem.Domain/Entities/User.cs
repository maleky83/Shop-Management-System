using ShopManagementSystem.Domain.Entities.Orders;
using System.ComponentModel.DataAnnotations;

namespace ShopManagementSystem.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(300)]
        public string Name { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public DateTime RegisterDate { get; set; }
        [Required]
        public bool IsAdmin { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
