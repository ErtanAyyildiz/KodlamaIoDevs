using Core.Application.Requests;
using KodlamaIoDevs.Application.Features.SocialMedia.Models;
using MediatR;

namespace KodlamaIoDevs.Application.Features.SocialMedia.Queries.GetListSocialMedia
{
    public class GetListSocialMediaQuery:IRequest<SocialMediaListModel>
    {
        public PageRequest PageRequest { get; set; }
    }
}
