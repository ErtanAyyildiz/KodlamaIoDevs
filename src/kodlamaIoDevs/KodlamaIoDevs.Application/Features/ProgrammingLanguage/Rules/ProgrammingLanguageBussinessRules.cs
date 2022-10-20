using Core.CrossCuttingConcerns.Exceptions;
using KodlamaIoDevs.Application.Features.ProgrammingLanguage.Constants;
using KodlamaIoDevs.Application.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaIoDevs.Application.Features.ProgrammingLanguage.Rules
{
    public class ProgrammingLanguageBussinessRules
    {
        private readonly IProgrammingLanguageRepository _programmingLanguageRepository;

        public ProgrammingLanguageBussinessRules(IProgrammingLanguageRepository programmingLanguageRepository)
        {
            _programmingLanguageRepository = programmingLanguageRepository;
        }

        public void ProgrammingLanguageExistWhenRequested(Domain.Entities.ProgrammingLanguage programmingLanguage)
        {
            if (programmingLanguage == null)
            {
                throw new BusinessException(BusinessRulesConstants.ProgrammingLanguageNotExist);
            }
        }

        public async Task ProgrammingLanguageNameCanNotBeDuplicatedWhenInserted(string name)
        {
            var result = await _programmingLanguageRepository.GetListAsync(x => x.Name == name);

            if (result.Items.Any())
            {
                throw new BusinessException(BusinessRulesConstants.ProgrammingLanguageExistsBefore);
            }
        }
    }
}
