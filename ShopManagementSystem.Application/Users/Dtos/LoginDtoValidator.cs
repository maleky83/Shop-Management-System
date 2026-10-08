using FluentValidation;

namespace ShopManagementSystem.Application.Users.Dtos;

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
