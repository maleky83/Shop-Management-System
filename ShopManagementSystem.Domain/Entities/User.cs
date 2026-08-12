using ShopManagementSystem.Domain.Entities.Orders;

namespace ShopManagementSystem.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public DateTime RegisterDate { get; set; }
        public bool IsAdmin { get; set; }

        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
