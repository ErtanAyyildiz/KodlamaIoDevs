using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaIoDevs.Application.Features.Technology.Commands.UpdateTechnology
{
    public class UpdateTechnologyCommandValidator:AbstractValidator<UpdateTechnologyCommand>
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
