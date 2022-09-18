using AutoMapper;
using KodlamaIoDevs.Application.Features.Technology.Dtos;
using KodlamaIoDevs.Application.Features.Technology.Rules;
using KodlamaIoDevs.Application.Services.Repositorties;
using MediatR;

namespace KodlamaIoDevs.Application.Features.Technology.Commands.CreateTechnology
{
    public class CreateTechnologyCommandHandler : IRequestHandler<CreateTechnologyCommand, CreatedTechnologyDto>
    {
        private readonly IMapper _mapper;
        private readonly TechnologyBusinessRules _technologyBusinessRules;
        private readonly ITechnologyRepository _technologyRepository;

        public CreateTechnologyCommandHandler(IMapper mapper, TechnologyBusinessRules technologyBusinessRules, ITechnologyRepository technologyRepository)
        {
            _mapper = mapper;
            _technologyBusinessRules = technologyBusinessRules;
            _technologyRepository = technologyRepository;
        }

        public async Task<CreatedTechnologyDto> Handle(CreateTechnologyCommand request, CancellationToken cancellationToken)
        {
            await _technologyBusinessRules.NameCanNotBeDuplicatedWhenInserted(request.Name);
            await _technologyBusinessRules.ShouldHaveValidForeignKey(request.ProgrammingLanguageId);

            var mappedTechnologyEntity = _mapper.Map<Domain.Entities.Technology>(request);
            var createdTechnologyEntity = await _technologyRepository.AddAsync(mappedTechnologyEntity);
            var createdTechnologyDto = _mapper.Map<CreatedTechnologyDto>(createdTechnologyEntity);
            return createdTechnologyDto;
        }
    }
}
