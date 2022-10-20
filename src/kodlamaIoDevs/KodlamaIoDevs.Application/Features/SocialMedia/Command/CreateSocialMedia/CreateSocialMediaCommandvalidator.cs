using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaIoDevs.Application.Features.SocialMedia.Command.CreateSocialMedia
{
    public class CreateSocialMediaCommandvalidator:AbstractValidator<CreateSocialMediaCommand>
    {
        public CreateSocialMediaCommandvalidator()
        {
            RuleFor(g => g.UserId).NotNull();

            RuleFor(g => g.Url).NotEmpty().NotNull();
        }
    }
}
