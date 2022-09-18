using AutoMapper;
using KodlamaIoDevs.Application.Features.Technology.Dtos;
using KodlamaIoDevs.Application.Features.Technology.Rules;
using KodlamaIoDevs.Application.Services.Repositorties;
using MediatR;

namespace KodlamaIoDevs.Application.Features.Technology.Commands.UpdateTechnology
{
    public class UpdateTechnologyCommandHandler : IRequestHandler<UpdateTechnologyCommand, UpdatedTechnologyDto>
    {
        private readonly IMapper _mapper;
        private readonly TechnologyBusinessRules _technologyBusinessRules;
        private readonly ITechnologyRepository _technologyRepository;

        public UpdateTechnologyCommandHandler(IMapper mapper, TechnologyBusinessRules technologyBusinessRules, ITechnologyRepository technologyRepository)
        {
            _mapper = mapper;
            _technologyBusinessRules = technologyBusinessRules;
            _technologyRepository = technologyRepository;
        }

        /// Todo: Update trace id hatası veriyor. Bakılacak !
        public async Task<UpdatedTechnologyDto> Handle(UpdateTechnologyCommand request, CancellationToken cancellationToken)
        {
            await _technologyBusinessRules.NameCanNotBeDuplicatedWhenInserted(request.Name);
            await _technologyBusinessRules.ShouldHaveValidForeignKey(request.ProgrammingLanguageId);
            await _technologyBusinessRules.ShouldHaveValidId(request.Id);

            Domain.Entities.Technology? mappedTechnologyEntitiy = _mapper.Map<Domain.Entities.Technology>(request);
            //var technologyEntity = await _technologyRepository.GetAsync(t => t.Id == request.Id);

            _technologyBusinessRules.TechnologyShouldExistWhenRequested(mappedTechnologyEntitiy);

            //var updatedTechnologyEntity = await _technologyRepository.DeleteAsync(technologyEntity);
            var updatedTechnologyEntity = _technologyRepository.Update(mappedTechnologyEntitiy);
            var updatedTechnologyDto = _mapper.Map<UpdatedTechnologyDto>(updatedTechnologyEntity);

            return updatedTechnologyDto;
        }
    }
}
