using FluentValidation;

namespace KodlamaIoDevs.Application.Features.SocialMedia.Commands.CreateSocialMedia
{
    public class CreateSocialMediaCommandValidator : AbstractValidator<CreateSocialMediaCommand>
    {
        public CreateSocialMediaCommandValidator()
        {
            RuleFor(g => g.UserId)
                .NotNull();

            RuleFor(g => g.Url)
                .NotEmpty()
                .NotNull();
        }
    }
}
