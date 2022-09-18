using FluentValidation;

namespace KodlamaIoDevs.Application.Features.Technology.Commands.UpdateTechnology
{
    public class UpdateTechnologyCommandValidator : AbstractValidator<UpdateTechnologyCommand>
    {
        public UpdateTechnologyCommandValidator()
        {
            RuleFor(t => t.Id)
                .NotEmpty();

            RuleFor(t => t.Name)
                .NotEmpty()
                .MinimumLength(1);

            RuleFor(t => t.ProgrammingLanguageId)
                .NotEmpty();
        }
    }
}
