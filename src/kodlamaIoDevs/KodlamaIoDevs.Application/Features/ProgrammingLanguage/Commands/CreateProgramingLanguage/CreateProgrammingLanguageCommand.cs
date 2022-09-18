using AutoMapper;
using KodlamaIoDevs.Application.Features.ProgrammingLanguage.Dtos;
using KodlamaIoDevs.Application.Features.ProgrammingLanguage.Rules;
using KodlamaIoDevs.Application.Services.Repositorties;
using MediatR;

namespace KodlamaIoDevs.Application.Features.ProgrammingLanguage.Commands.CreateProgramingLanguage
{
    public class CreateProgrammingLanguageCommand: IRequest<CreatedProgrammingLanguageDto>
    {
        public string Name { get; set; }

        public class CreateProgrammingLanguageCommandHandler : IRequestHandler<CreateProgrammingLanguageCommand, CreatedProgrammingLanguageDto>
        {
            private readonly IProgrammingLanguageRepository _programmingLanguageRepository;
            private readonly IMapper _mapper;
            private readonly ProgramingLanguageBussinessRules _programingLanguageBussinessRules;

            public CreateProgrammingLanguageCommandHandler(IProgrammingLanguageRepository programmingLanguageRepository, IMapper mapper, ProgramingLanguageBussinessRules programingLanguageBussinessRules)
            {
                _programmingLanguageRepository = programmingLanguageRepository;
                _mapper = mapper;
                _programingLanguageBussinessRules = programingLanguageBussinessRules;
            }

            public async Task<CreatedProgrammingLanguageDto> Handle(CreateProgrammingLanguageCommand request, CancellationToken cancellationToken)
            {
                await _programingLanguageBussinessRules.ProgrammingLanguageNameCanNotBeDuplicatedWhenInserted(request.Name);
               
                var mappedProgrammingLanguageEntitiy = _mapper.Map<Domain.Entities.ProgrammingLanguage>(request);
                var createdProgrammingLanguage = await _programmingLanguageRepository.AddAsync(mappedProgrammingLanguageEntitiy);
                var createdProgrammingLanguageDto = _mapper.Map<CreatedProgrammingLanguageDto>(createdProgrammingLanguage);

                return createdProgrammingLanguageDto;
            }
        }
    }
}
