using FluentValidation;
using ShopManagementSystem.Application.DTOs.Product;

namespace ShopManagementSystem.Application.Validators;

public sealed class CreateProductDtoValidator : AbstractValidator<CreateProductDto>
{
    public CreateProductDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(50);

        RuleFor(x => x.Description)
            .MaximumLength(500)
            .When(x => x.Description is not null);

        RuleFor(x => x.Price)
            .NotEmpty();

        RuleFor(x => x.Quantity)
            .NotEmpty();

        RuleFor(x => x.CategoryId)
            .NotEmpty();
    }
}
