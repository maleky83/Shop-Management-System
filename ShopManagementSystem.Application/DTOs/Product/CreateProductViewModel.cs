using ShopManagementSystem.Domain.Entities;

namespace ShopManagementSystem.Application.DTOs.ProductViewModels
{
    public class CreateProductViewModel
    {
        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }

        public string? PictureName { get; set; }

        public decimal Price { get; set; }

        public int QuantityInStock { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        #region Relations

        public ICollection<CategoryToProduct> CategoryToProducts { get; set; }
            = new List<CategoryToProduct>();

        public ICollection<OrderDetail> OrderDetails { get; set; }
            = new List<OrderDetail>();

        public ICollection<CartItem> CartItems { get; set; }
            = new List<CartItem>();

        #endregion
    }
}