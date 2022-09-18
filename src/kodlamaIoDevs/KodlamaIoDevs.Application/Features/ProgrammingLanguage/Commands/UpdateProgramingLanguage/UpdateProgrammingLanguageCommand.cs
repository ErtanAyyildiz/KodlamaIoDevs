using AutoMapper;
using KodlamaIoDevs.Application.Features.ProgrammingLanguage.Dtos;
using KodlamaIoDevs.Application.Features.ProgrammingLanguage.Rules;
using KodlamaIoDevs.Application.Services.Repositorties;
using MediatR;

namespace KodlamaIoDevs.Application.Features.ProgrammingLanguage.Commands.UpdateProgramingLanguage
{
    public class UpdateProgrammingLanguageCommand: IRequest<UpdatedProgrammingLanguageDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public class UpdateProgrammingLanguageCommandHandler : IRequestHandler<UpdateProgrammingLanguageCommand, UpdatedProgrammingLanguageDto>
        {
            private readonly IProgrammingLanguageRepository _programmingLanguageRepository;
            private readonly IMapper _mapper;
            private readonly ProgramingLanguageBussinessRules _programingLanguageBussinessRules;

            public UpdateProgrammingLanguageCommandHandler(IProgrammingLanguageRepository programmingLanguageRepository, IMapper mapper, ProgramingLanguageBussinessRules programingLanguageBussinessRules)
            {
                _programmingLanguageRepository = programmingLanguageRepository;
                _mapper = mapper;
                _programingLanguageBussinessRules = programingLanguageBussinessRules;
            }

            public async Task<UpdatedProgrammingLanguageDto> Handle(UpdateProgrammingLanguageCommand request, CancellationToken cancellationToken)
            {
                await _programingLanguageBussinessRules.ProgrammingLanguageNameCanNotBeDuplicatedWhenInserted(request.Name);

                var mappedProgrammingLanguageEntitiy = _mapper.Map<Domain.Entities.ProgrammingLanguage>(request);
                //var updatedProgrammingLanguage = await _programmingLanguageRepository.DeleteAsync(mappedProgrammingLanguageEntitiy);
                var updatedProgrammingLanguage =  _programmingLanguageRepository.Update(mappedProgrammingLanguageEntitiy);
                var updatedProgrammingLanguageDto = _mapper.Map<UpdatedProgrammingLanguageDto>(updatedProgrammingLanguage);

                return updatedProgrammingLanguageDto;
            }
        }
    }
}
