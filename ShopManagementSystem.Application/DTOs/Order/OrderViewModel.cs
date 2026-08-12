namespace ShopManagementSystem.Application.DTOs.OrderViewModels
{
    public class OrderViewModel
    {
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public bool IsFinaly { get; set; }
        public long Sum { get; set; }
        public ICollection<OrderDetailViewModel> OrderDetails { get; set; }
    }
}
