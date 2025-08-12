
using FluentValidation;
using RAC.Communication.Requests;

namespace RAC.Application.UseCases.Users;

public class UserValidator : AbstractValidator<RequestUser>
{
    public UserValidator()
    {
        RuleFor(user => user.Name).NotEmpty().WithMessage("Name is required");
        RuleFor(user => user.Email)
            .NotEmpty().WithMessage("Email is required")
            .EmailAddress().WithMessage("Invalid email format");

        RuleFor(user => user.Password).SetValidator(new PasswordValidator<RequestUser>());
    }
}
