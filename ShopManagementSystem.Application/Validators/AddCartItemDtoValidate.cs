using FluentValidation;
using ShopManagementSystem.Application.DTOs.Cart;

namespace ShopManagementSystem.Application.Validators;

public sealed class AddCartItemDtoValidate : AbstractValidator<AddCartiItemDto>
{
    public AddCartItemDtoValidate()
    {
        RuleFor(x => x.ProductId)
            .NotEmpty();

        RuleFor(x => x.Quantity)
            .NotEmpty();
    }
}
