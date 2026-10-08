using FluentValidation;
using ShopManagementSystem.Application.Carts.Dtos;

namespace ShopManagementSystem.Application.Carts.Validators;

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
