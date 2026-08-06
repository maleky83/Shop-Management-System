
namespace ShopManagementSystem.Core.DTOs.OrderViewModels
{
    public class OrderDetailViewModel
    {
        public int DetailId { get; set; }
        public int ProductId { get; set; }
        public long Price { get; set; }
        public int Count { get; set; }
        public string ProductName { get; set; }

    }
}
