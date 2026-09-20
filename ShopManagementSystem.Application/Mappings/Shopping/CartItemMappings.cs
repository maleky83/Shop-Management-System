using ShopManagementSystem.Application.DTOs.Cart;
using ShopManagementSystem.Domain.Entities.Carts;

namespace ShopManagementSystem.Application.Mappings.Shopping;

internal static class CartItemMappings
{
    public static CartItemDto ToDto(this CartItem cartItem)
    {
        return new CartItemDto
        {
            CartItemId = cartItem.Id,
            ProductName = cartItem.Product.Name,
            ProductId = cartItem.ProductId,
            Quantity = cartItem.Quantity,
            UnitPrice = cartItem.UnitPrice,
            TotalPrice = cartItem.UnitPrice * cartItem.Quantity
        };
    }
}
