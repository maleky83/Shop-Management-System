using FluentValidation;

namespace ShopManagementSystem.Application.Orders.Commands.CreateOrder;

public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
{
    public CreateOrderCommandValidator()
    {
        RuleFor(x => x.TotalPrice)
            .NotEmpty();
    }
}
