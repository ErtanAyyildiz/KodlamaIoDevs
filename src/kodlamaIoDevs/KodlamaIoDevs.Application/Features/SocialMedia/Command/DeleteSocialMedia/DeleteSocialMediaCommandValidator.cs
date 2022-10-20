using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaIoDevs.Application.Features.SocialMedia.Command.DeleteSocialMedia
{
    public class DeleteSocialMediaCommandValidator:AbstractValidator<DeleteSocialMediaCommand>
    {
        public DeleteSocialMediaCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
