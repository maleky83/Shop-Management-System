namespace ShopManagementSystem.Application.DTOs.Product;

public class ProductViewModel
{
    public int ProductId { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public string? PictureName { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public int CategoryId { get; set; }
}
