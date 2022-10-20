using Core.Persistence.Paging;
using KodlamaIoDevs.Application.Features.Technology.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaIoDevs.Application.Features.Technology.Models
{
    public class TechnologyListModel : BasePageableModel
    {
        public IList<TechnologyListDto> Items { get; set; }
    }
}
