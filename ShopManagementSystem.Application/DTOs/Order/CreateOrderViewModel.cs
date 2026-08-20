namespace ShopManagementSystem.Application.DTOs.Order
{
    public class CreateOrderViewModel
    {
        public int UserId { get; set; }
        public OrderStatus Status { get; set; } = OrderStatus.Pending;
        public decimal TotalPrice { get; set; }
    }
}
