using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaIoDevs.Application.Features.SocialMedia.Command.UpdateSocialMedia
{
    public class UpdateSocialMediaCommandValidator:AbstractValidator<UpdateSocialMediaCommand>
    {
        public UpdateSocialMediaCommandValidator()
        {
            RuleFor(g => g.Id)
                .NotNull();

            RuleFor(g => g.Url)
                .NotNull()
                .NotEmpty();

            RuleFor(g => g.UserId)
                .NotNull()
                .NotEmpty();
        }
    }
}
