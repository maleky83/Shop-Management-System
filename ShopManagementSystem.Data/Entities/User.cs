using ShopManagementSystem.Data.Entities.Orders;
using System.ComponentModel.DataAnnotations;

namespace ShopManagementSystem.Data.Entities
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

        public List<Order> Orders { get; set; }
    }
}
