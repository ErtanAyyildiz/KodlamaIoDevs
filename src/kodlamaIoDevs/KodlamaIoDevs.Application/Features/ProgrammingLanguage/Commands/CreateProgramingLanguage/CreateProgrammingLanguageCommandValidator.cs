using FluentValidation;

namespace KodlamaIoDevs.Application.Features.ProgrammingLanguage.Commands.CreateProgramingLanguage
{
    public class CreateProgrammingLanguageCommandValidator: AbstractValidator<CreateProgrammingLanguageCommand>
    {
        public CreateProgrammingLanguageCommandValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty();
        }
    }
}
