using FluentValidation;
using ShopManagementSystem.Application.DTOs.Account;

namespace ShopManagementSystem.Application.Validators;

public sealed class LoginDtoValidator : AbstractValidator<LoginDto>
{
    public LoginDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty();

        RuleFor(x => x.Password)
            .NotEmpty();
    }
}
