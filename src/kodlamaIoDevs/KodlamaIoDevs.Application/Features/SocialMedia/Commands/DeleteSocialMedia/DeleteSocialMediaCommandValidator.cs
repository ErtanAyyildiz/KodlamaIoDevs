using FluentValidation;

namespace KodlamaIoDevs.Application.Features.SocialMedia.Commands.DeleteSocialMedia
{
    public class DeleteSocialMediaCommandValidator: AbstractValidator<DeleteSocialMediaCommand>
    {
        public DeleteSocialMediaCommandValidator()
        {
            RuleFor(p => p.Id)
                .NotEmpty();
        }
    }
}
