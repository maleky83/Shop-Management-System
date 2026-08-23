namespace ShopManagementSystem.Application.DTOs.Cart
{
    public class CartViewModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public List<CartItemViewModel> CartItems { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
