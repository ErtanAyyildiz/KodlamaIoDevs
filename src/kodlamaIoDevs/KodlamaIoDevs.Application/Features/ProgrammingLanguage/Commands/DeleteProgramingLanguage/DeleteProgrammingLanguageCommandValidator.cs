using FluentValidation;

namespace KodlamaIoDevs.Application.Features.ProgrammingLanguage.Commands.DeleteProgramingLanguage
{
    public class DeleteProgrammingLanguageCommandValidator: AbstractValidator<DeleteProgrammingLanguageCommand>
    {
        public DeleteProgrammingLanguageCommandValidator()
        {
            RuleFor(c => c.Id)
                .NotEmpty();
        }
    }
}
