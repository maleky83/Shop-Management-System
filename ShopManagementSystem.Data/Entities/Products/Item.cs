
namespace ShopManagementSystem.Data.Entities.Products
{
    public class Item
    {
        public int Id { get; set; }
        public long Price { get; set; }
        public int QuantityInStock { get; set; }

        // Navigation Property
        public Product Product { get; set; }
    }
}
