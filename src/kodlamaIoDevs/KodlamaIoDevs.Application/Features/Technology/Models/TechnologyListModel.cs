using Core.Persistence.Paging;
using KodlamaIoDevs.Application.Features.Technology.Dtos;

namespace KodlamaIoDevs.Application.Features.Technology.Models
{
    public class TechnologyListModel: BasePageableModel
    {
        public IList<TechnologyListDto> Items { get; set; }
    }
}
