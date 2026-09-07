using ShopManagementSystem.Domain.Entities.Identity;

namespace ShopManagementSystem.Domain.Entities.Carts;

public sealed class Cart : BaseEntity
{
    public int UserId { get; set; }

    public User User { get; set; } = null!;

    #region Relations

    public ICollection<CartItem> CartItems { get; }
        = new List<CartItem>();

    #endregion
}
