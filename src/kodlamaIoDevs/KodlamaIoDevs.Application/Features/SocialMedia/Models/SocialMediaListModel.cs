using Core.Persistence.Paging;
using KodlamaIoDevs.Application.Features.SocialMedia.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaIoDevs.Application.Features.SocialMedia.Models
{
    public class SocialMediaListModel : BasePageableModel
    {
        public ICollection<SocialMediaListDto> Items { get; set; }
    }
}
