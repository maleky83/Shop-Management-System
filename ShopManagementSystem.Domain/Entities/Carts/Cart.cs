using ShopManagementSystem.Domain.Entities.Identity;

namespace ShopManagementSystem.Domain.Entities.Carts;

public class Cart : BaseEntity
{
    public int UserId { get; set; }

    public User User { get; set; } = null!;

    #region Relations

    public ICollection<CartItem> Items { get; set; }
        = new List<CartItem>();

    #endregion
}