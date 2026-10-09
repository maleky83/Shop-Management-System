using FluentValidation;

namespace ShopManagementSystem.Application.CartItems.Commands.CreateCartItem;

public class CreateCartItemCommandValidator : AbstractValidator<CreateCartItemCommand>
{
    public CreateCartItemCommandValidator()
    {
        RuleFor(x => x.Quantity)
            .NotEmpty();
    }
}
