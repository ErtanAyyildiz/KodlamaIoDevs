using AutoMapper;
using KodlamaIoDevs.Application.Features.Technology.Dtos;
using KodlamaIoDevs.Application.Features.Technology.Rules;
using KodlamaIoDevs.Application.Services.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaIoDevs.Application.Features.Technology.Commands.CreateTechnology
{
    public class CreateTechnologyCommand:IRequest<CreatedTechnologyDto>
    {
        public string Name { get; set; }
        public int ProgrammingLanguageId { get; set; }

        public class CreateTechnologyCommandHandler : IRequestHandler<CreateTechnologyCommand, CreatedTechnologyDto>
        {
            private readonly IMapper _mapper;
            private readonly ITechnologyRepository _technologyRepository;
            private readonly TechnologyBusinessRules _technologyBusinessRules;

            public CreateTechnologyCommandHandler(IMapper mapper, ITechnologyRepository technologyRepository, TechnologyBusinessRules technologyBusinessRules)
            {
                _mapper = mapper;
                _technologyRepository = technologyRepository;
                _technologyBusinessRules = technologyBusinessRules;
            }

            public async Task<CreatedTechnologyDto> Handle(CreateTechnologyCommand request, CancellationToken cancellationToken)
            {
                await _technologyBusinessRules.NameCanNotBeDuplicateWhenInserted(request.Name);
                await _technologyBusinessRules.ShouldHaveValidForeignKey(request.ProgrammingLanguageId);

                var mappedTechnologyEntity = _mapper.Map<Domain.Entities.Technology>(request);
                var createdTechnologyEntity=await _technologyRepository.AddAsync(mappedTechnologyEntity);
                var createdTechnologyDto=_mapper.Map<CreatedTechnologyDto>(createdTechnologyEntity);

                return createdTechnologyDto;
            }
        }
    }
}
