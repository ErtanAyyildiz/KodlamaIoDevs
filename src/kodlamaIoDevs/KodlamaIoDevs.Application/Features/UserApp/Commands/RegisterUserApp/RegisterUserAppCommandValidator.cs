using FluentValidation;

namespace KodlamaIoDevs.Application.Features.UserApp.Commands.RegisterUserApp
{
    public class RegisterUserAppCommandValidator: AbstractValidator<RegisterUserAppCommand>
    {
        public RegisterUserAppCommandValidator()
        {
            RuleFor(x => x.Email)
                .NotNull()
                .NotEmpty()
                .EmailAddress();

            RuleFor(x => x.FirstName)
                .MinimumLength(2)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.LastName)
                .MinimumLength(2)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.Password)
                .MinimumLength(6)
                .NotEmpty()
                .NotNull();
        }
    }
}
