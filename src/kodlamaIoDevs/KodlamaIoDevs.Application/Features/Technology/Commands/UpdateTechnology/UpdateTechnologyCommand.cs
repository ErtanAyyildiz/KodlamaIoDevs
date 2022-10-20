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

namespace KodlamaIoDevs.Application.Features.Technology.Commands.UpdateTechnology
{
    public class UpdateTechnologyCommand:IRequest<UpdatedTechnologyDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ProgrammingLanguageId { get; set; }

        public class UpdateTechnologyCommandHandler : IRequestHandler<UpdateTechnologyCommand, UpdatedTechnologyDto>
        {
            private readonly IMapper _mapper;
            private readonly ITechnologyRepository _technologyRepository;
            private readonly TechnologyBusinessRules _technologyBusinessRules;

            public UpdateTechnologyCommandHandler(IMapper mapper, ITechnologyRepository technologyRepository, TechnologyBusinessRules technologyBusinessRules)
            {
                _mapper = mapper;
                _technologyRepository = technologyRepository;
                _technologyBusinessRules = technologyBusinessRules;
            }

            public async Task<UpdatedTechnologyDto> Handle(UpdateTechnologyCommand request, CancellationToken cancellationToken)
            {
                await _technologyBusinessRules.NameCanNotBeDuplicateWhenInserted(request.Name);
                await _technologyBusinessRules.ShouldHaveValidForeignKey(request.ProgrammingLanguageId);
                await _technologyBusinessRules.ShouldHaveValidId(request.Id);

                Domain.Entities.Technology? mappedTechnologyEntity = _mapper.Map<Domain.Entities.Technology>(request);

                _technologyBusinessRules.TechnologyShouldExistWhenRequested(mappedTechnologyEntity);

                var updatedTechnologyEntity = _technologyRepository.Update(mappedTechnologyEntity);
                var updatedTechnologyDto=_mapper.Map<UpdatedTechnologyDto>(updatedTechnologyEntity);

                return updatedTechnologyDto;
            }
        }
    }
}
