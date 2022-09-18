using FluentValidation;

namespace KodlamaIoDevs.Application.Features.UserApp.Commands.LoginUserApp
{
    public class LoginUserAppCommandValidator: AbstractValidator<LoginUserAppCommand>
    {
        public LoginUserAppCommandValidator()
        {
            RuleFor(d => d.Email)
                .NotEmpty()
                .NotNull()
                .EmailAddress();

            RuleFor(d => d.Password)
                .NotEmpty()
                .NotNull()
                .MinimumLength(6);
        }
    }
}
