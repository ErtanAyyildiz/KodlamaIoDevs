using KodlamaIoDevs.Application.Features.SocialMedia.Dtos;
using MediatR;

namespace KodlamaIoDevs.Application.Features.SocialMedia.Commands.DeleteSocialMedia
{
    public class DeleteSocialMediaCommand: IRequest<DeletedSocialMediaDto>
    {
        public int Id { get; set; }
    }
}
