using Core.Persistence.Paging;
using KodlamaIoDevs.Application.Features.SocialMedia.Dtos;

namespace KodlamaIoDevs.Application.Features.SocialMedia.Models
{
    public class SocialMediaListModel: BasePageableModel
    {
        public ICollection<SocialMediaListDto> Items { get; set; }
    }
}
