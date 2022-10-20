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

namespace KodlamaIoDevs.Application.Features.ProgrammingLanguage.Commands.DeleteProgrammingLanguage
{
    public class DeleteProgrammingLanguageCommand:IRequest<DeletedProgrammingLanguageDto>
    {
        public int Id { get; set; }

        public class DeleteProgrammingLanguageCommandHandler : IRequestHandler<DeleteProgrammingLanguageCommand, DeletedProgrammingLanguageDto>
        {
            private readonly IProgrammingLanguageRepository _programmingLanguageRepository;
            private readonly IMapper _mapper;
            private readonly ProgrammingLanguageBussinessRules _programmingLanguageBussinessRules;

            public DeleteProgrammingLanguageCommandHandler(IProgrammingLanguageRepository programmingLanguageRepository, IMapper mapper, ProgrammingLanguageBussinessRules programmingLanguageBussinessRules)
            {
                _programmingLanguageRepository = programmingLanguageRepository;
                _mapper = mapper;
                _programmingLanguageBussinessRules = programmingLanguageBussinessRules;
            }

            public async Task<DeletedProgrammingLanguageDto> Handle(DeleteProgrammingLanguageCommand request, CancellationToken cancellationToken)
            {
                var programmingLanguageEntity=await _programmingLanguageRepository.GetAsync(x => x.Id == request.Id);
                _programmingLanguageBussinessRules.ProgrammingLanguageExistWhenRequested(programmingLanguageEntity);

                var deletedProgrammingLanguage =await _programmingLanguageRepository.DeleteAsync(programmingLanguageEntity);
                var deletedProgrammingLanguageDto = _mapper.Map<DeletedProgrammingLanguageDto>(deletedProgrammingLanguage);

                return deletedProgrammingLanguageDto;
            }
        }
    }
}
