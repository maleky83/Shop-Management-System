namespace ShopManagementSystem.Domain.Entities;

public class Cart : BaseEntity
{
    public int UserId { get; set; }

    public User.User User { get; set; } = null!;

    #region Relations

    public ICollection<CartItem> Items { get; set; }
        = new List<CartItem>();

    #endregion
}