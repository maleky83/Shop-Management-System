namespace ShopManagementSystem.Application.DTOs.Cart
{
    public class CartItemViewModel
    {
        public int Id { get; set; }
        public decimal TotalPrice { get; set; }
        public int ProductId { get; set; }
        public required string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
    }
}
