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

namespace KodlamaIoDevs.Application.Features.ProgrammingLanguage.Commands.UpdateProgrammingLanguage
{
    public class UpdateProgrammingLanguageCommand:IRequest<UpdateProgrammingLanguageDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public class UpdateProgrammingLanguageCommandHandler : IRequestHandler<UpdateProgrammingLanguageCommand, UpdateProgrammingLanguageDto>
        {
            private readonly IProgrammingLanguageRepository _programmingLanguageRepository;
            private readonly IMapper _mapper;
            private readonly ProgrammingLanguageBussinessRules _programmingLanguageBussinessRules;

            public UpdateProgrammingLanguageCommandHandler(IProgrammingLanguageRepository programmingLanguageRepository, IMapper mapper, ProgrammingLanguageBussinessRules programmingLanguageBussinessRules)
            {
                _programmingLanguageRepository = programmingLanguageRepository;
                _mapper = mapper;
                _programmingLanguageBussinessRules = programmingLanguageBussinessRules;
            }

            public async Task<UpdateProgrammingLanguageDto> Handle(UpdateProgrammingLanguageCommand request, CancellationToken cancellationToken)
            {
                await _programmingLanguageBussinessRules.ProgrammingLanguageNameCanNotBeDuplicatedWhenInserted(request.Name);

                var mappedProgrammingLanguageEntity=_mapper.Map<Domain.Entities.ProgrammingLanguage>(request);
                //var updatedProgrammingLanguage = await _programmingLanguageRepository.DeleteAsync(mappedProgrammingLanguageEntitiy);
                var updatedProgrammingLanguage = _programmingLanguageRepository.Update(mappedProgrammingLanguageEntity);
                var updatedProgrammingDto=_mapper.Map<UpdateProgrammingLanguageDto>(updatedProgrammingLanguage);

                return updatedProgrammingDto;
            }
        }
    }
}
