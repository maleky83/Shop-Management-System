using FluentValidation;

namespace ShopManagementSystem.Application.CartItems.Commands.UpdateCartItem;

public class UpdateCartItemCommandValidator : AbstractValidator<UpdateCartItemCommand>
{
    public UpdateCartItemCommandValidator()
    {
        RuleFor(x => x.Quantity)
            .NotEmpty();
    }
}
