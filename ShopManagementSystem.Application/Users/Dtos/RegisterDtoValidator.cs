using FluentValidation;

namespace ShopManagementSystem.Application.Users.Dtos;

public class RegisterDtoValidator : AbstractValidator<RegisterDto>
{
    public RegisterDtoValidator()
    {
        RuleFor(x => x.Name)
            .Length(3, 100);

        RuleFor(x => x.Password)
            .Length(3, 50);

        RuleFor(x => x.RePassword)
            .Matches(x => x.Password);
    }
}
