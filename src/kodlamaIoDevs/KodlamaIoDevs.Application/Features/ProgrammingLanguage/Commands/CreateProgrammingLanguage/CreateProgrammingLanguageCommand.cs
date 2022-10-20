using AutoMapper;
using KodlamaIoDevs.Application.Features.ProgrammingLanguage.Dtos;
using KodlamaIoDevs.Application.Features.ProgrammingLanguage.Rules;
using KodlamaIoDevs.Application.Services.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaIoDevs.Application.Features.ProgrammingLanguage.Commands.CreateProgrammingLanguage
{
    public class CreateProgrammingLanguageCommand : IRequest<CreatedProgrammingLanguageDto>
    {
        public string Name { get; set; }

        public class CreateProgrammingLanguageCommandHandler : IRequestHandler<CreateProgrammingLanguageCommand, CreatedProgrammingLanguageDto>
        {
            private readonly IProgrammingLanguageRepository _programmingLanguageRepository;
            private readonly IMapper _mapper;
            private readonly ProgrammingLanguageBussinessRules _programmingLanguageBussinessRules;

            public CreateProgrammingLanguageCommandHandler(IProgrammingLanguageRepository programmingLanguageRepository, IMapper mapper, ProgrammingLanguageBussinessRules programmingLanguageBussinessRules)
            {
                _programmingLanguageRepository = programmingLanguageRepository;
                _mapper = mapper;
                _programmingLanguageBussinessRules = programmingLanguageBussinessRules;
            }

            public async Task<CreatedProgrammingLanguageDto> Handle(CreateProgrammingLanguageCommand request, CancellationToken cancellationToken)
            {
                await _programmingLanguageBussinessRules.ProgrammingLanguageNameCanNotBeDuplicatedWhenInserted(request.Name);

                var mappedProgrammingLanguageEntity = _mapper.Map<Domain.Entities.ProgrammingLanguage>(request);
                var createdProgrammingLanguage=await _programmingLanguageRepository.AddAsync(mappedProgrammingLanguageEntity);
                var createdProgrammingLanguageDto=_mapper.Map<CreatedProgrammingLanguageDto>(createdProgrammingLanguage);

                return createdProgrammingLanguageDto;

            }
        }
    }

}

