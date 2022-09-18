using FluentValidation;

namespace KodlamaIoDevs.Application.Features.Technology.Commands.CreateTechnology
{
    public class CreateTechnologyCommandValidator: AbstractValidator<CreateTechnologyCommand>
    {
        public CreateTechnologyCommandValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty()
                .MinimumLength(1);

            RuleFor(p => p.ProgrammingLanguageId)
                .NotEmpty();
        }
    }
}
