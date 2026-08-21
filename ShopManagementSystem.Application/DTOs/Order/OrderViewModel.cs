namespace ShopManagementSystem.Application.DTOs.Order
{
    public class OrderViewModel
    {
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public bool IsFinaly { get; set; }
        public long Sum { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public ICollection<OrderDetailViewModel> OrderDetails { get; set; }
    }
}
