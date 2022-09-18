using Core.Application.Requests;
using KodlamaIoDevs.Application.Features.Technology.Models;
using MediatR;

namespace KodlamaIoDevs.Application.Features.Technology.Queries.GetListTecnology
{
    public class GetListTechnologyQuery: IRequest<TechnologyListModel>
    {
        public PageRequest PageRequest { get; set; }
    }
}
