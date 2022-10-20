using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaIoDevs.Application.Features.Technology.Commands.DeleteTechnology
{
    public class DeleteTechnologyCommandValidator:AbstractValidator<DeleteTechnologyCommand>
    {
        public DeleteTechnologyCommandValidator()
        {
            RuleFor(p => p.Id).NotEmpty();
        }
    }
}
