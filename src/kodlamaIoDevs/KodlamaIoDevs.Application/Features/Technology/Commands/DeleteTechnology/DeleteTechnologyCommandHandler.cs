using AutoMapper;
using KodlamaIoDevs.Application.Features.Technology.Dtos;
using KodlamaIoDevs.Application.Features.Technology.Rules;
using KodlamaIoDevs.Application.Services.Repositorties;
using MediatR;

namespace KodlamaIoDevs.Application.Features.Technology.Commands.DeleteTechnology
{
    public class DeleteTechnologyCommandHandler : IRequestHandler<DeleteTechnologyCommand, DeletedTechnologyDto>
    {
        private readonly IMapper _mapper;
        private readonly TechnologyBusinessRules _technologyBusinessRules;
        private readonly ITechnologyRepository _technologyRepository;

        public DeleteTechnologyCommandHandler(IMapper mapper, TechnologyBusinessRules technologyBusinessRules, ITechnologyRepository technologyRepository)
        {
            _mapper = mapper;
            _technologyBusinessRules = technologyBusinessRules;
            _technologyRepository = technologyRepository;
        }

        public async Task<DeletedTechnologyDto> Handle(DeleteTechnologyCommand request, CancellationToken cancellationToken)
        {
            Domain.Entities.Technology? technologyEntity = await _technologyRepository.GetAsync(x => x.Id == request.Id);

            var deletedTechnologyEntity = await _technologyRepository.DeleteAsync(technologyEntity);

            var deletedTechnologyDto = _mapper.Map<DeletedTechnologyDto>(deletedTechnologyEntity);

            return deletedTechnologyDto;
        }
    }
}
