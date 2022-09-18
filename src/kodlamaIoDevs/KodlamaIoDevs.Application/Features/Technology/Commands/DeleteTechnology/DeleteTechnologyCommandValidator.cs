using FluentValidation;

namespace KodlamaIoDevs.Application.Features.Technology.Commands.DeleteTechnology
{
    public class DeleteTechnologyCommandValidator: AbstractValidator<DeleteTechnologyCommand>
    {
        public DeleteTechnologyCommandValidator()
        {
            RuleFor(p => p.Id)
               .NotEmpty();
            
        }
    }
}
