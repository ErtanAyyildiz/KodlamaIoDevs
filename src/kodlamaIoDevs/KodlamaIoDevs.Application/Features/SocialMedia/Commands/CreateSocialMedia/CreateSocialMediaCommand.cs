using KodlamaIoDevs.Application.Features.SocialMedia.Dtos;
using MediatR;

namespace KodlamaIoDevs.Application.Features.SocialMedia.Commands.CreateSocialMedia
{
    public class CreateSocialMediaCommand: IRequest<CreatedSocialMediaDto>
    {
        public int UserId { get; set; }
        public string Url { get; set; }
    }
}
