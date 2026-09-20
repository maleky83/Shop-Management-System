using ShopManagementSystem.Domain.Entities.Identity;

namespace ShopManagementSystem.Domain.Entities.Carts;

public sealed class Cart
{
    public string Id { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public required string UserId { get; set; }

    public User User { get; set; } = null!;

    #region Relations

    public ICollection<CartItem> CartItems { get; }
        = new List<CartItem>();

    #endregion
}
