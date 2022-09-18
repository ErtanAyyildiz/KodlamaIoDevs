using KodlamaIoDevs.Application.Features.SocialMedia.Dtos;
using MediatR;

namespace KodlamaIoDevs.Application.Features.SocialMedia.Commands.UpdateSocialMedia
{
    public class UpdateSocialMediaCommand: IRequest<UpdatedSocialMediaDto>
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public int UserId { get; set; }
    }
}
