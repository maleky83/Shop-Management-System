using System.ComponentModel.DataAnnotations;

namespace ShopManagementSystem.Core.DTOs.OrderViewModels
{
    public class OrderViewModel
    {
        [Key]
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public bool IsFinaly { get; set; }
        public long Sum { get; set; }
        public ICollection<OrderDetailViewModel> OrderDetails { get; set; }
    }
}
