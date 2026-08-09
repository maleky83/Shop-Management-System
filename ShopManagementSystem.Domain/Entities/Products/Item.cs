namespace ShopManagementSystem.Domain.Entities.Products
{
    public class Item
    {
        public int Id { get; set; }
        public long Price { get; set; }
        public int QuantityInStock { get; set; }

        public Product Product { get; set; }
    }
}
