using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaIoDevs.Application.Features.Technology.Commands.CreateTechnology
{
    public class CreateTechnologyValidator:AbstractValidator<CreateTechnologyCommand>
    {
        public CreateTechnologyValidator()
        {
            RuleFor(t => t.Name).NotEmpty().MinimumLength(2);
            RuleFor(t => t.ProgrammingLanguageId).NotEmpty();
        }
    }
}
