using ShopManagementSystem.Domain.Entities.Products;
using System.ComponentModel.DataAnnotations;

namespace ShopManagementSystem.Domain.Entities.Orders
{
    public class OrderDetail
    {
        public int Id { get; set; }
        [Required]
        public int OrderId { get; set; }
        [Required]
        public int ProductId { get; set; }
        [Required]
        public long Price { get; set; }
        public int Count { get; set; }

        public Order Order { get; set; } = null!;
        public Product Product { get; set; } = null!;
    }
}
