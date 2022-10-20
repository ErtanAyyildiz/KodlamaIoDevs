using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using KodlamaIoDevs.Application.Features.Technology.Models;
using KodlamaIoDevs.Application.Services.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaIoDevs.Application.Features.Technology.Queries.GetListTechnologyQuery
{
    public class GetListTechnologyQuery:IRequest<TechnologyListModel>
    {
        public PageRequest PageRequest { get; set; }

        public class GetListTechnologyQueryHandler : IRequestHandler<GetListTechnologyQuery, TechnologyListModel>
        {
            private readonly IMapper _mapper;
            private readonly ITechnologyRepository _technologyRepository;

            public GetListTechnologyQueryHandler(IMapper mapper, ITechnologyRepository technologyRepository)
            {
                _mapper = mapper;
                _technologyRepository = technologyRepository;
            }

            public async Task<TechnologyListModel> Handle(GetListTechnologyQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Domain.Entities.Technology> technologies=await _technologyRepository.GetListAsync(
                    include:t=>t.Include(x=>x.ProgrammingLanguage),
                    index:request.PageRequest.Page,
                    size:request.PageRequest.PageSize,
                    cancellationToken:cancellationToken
                    );

                TechnologyListModel mappedTechnologyListModel = _mapper.Map<TechnologyListModel>(technologies);

                return mappedTechnologyListModel;
            }
        }
    }
}
