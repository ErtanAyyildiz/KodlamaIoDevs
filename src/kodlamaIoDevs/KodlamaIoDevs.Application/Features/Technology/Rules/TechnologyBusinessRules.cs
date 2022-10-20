using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using KodlamaIoDevs.Application.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaIoDevs.Application.Features.Technology.Rules
{
    public class TechnologyBusinessRules
    {
        private readonly ITechnologyRepository _technologyRepository;
        private readonly IProgrammingLanguageRepository _programmingLanguageRepository;

        public TechnologyBusinessRules(ITechnologyRepository technologyRepository, IProgrammingLanguageRepository programmingLanguageRepository)
        {
            _technologyRepository = technologyRepository;
            _programmingLanguageRepository = programmingLanguageRepository;
        }


        public async Task NameCanNotBeDuplicateWhenInserted(string name)
        {
            IPaginate<Domain.Entities.Technology> result = await _technologyRepository.GetListAsync(t => t.Name == name);
            if (result.Items.Any())
            {
                throw new BusinessException("Technology's name exists!");
            }
        }

        public async Task ShouldHaveValidForeignKey(int programmingLanguageId)
        {
            Domain.Entities.ProgrammingLanguage? result =await _programmingLanguageRepository.GetAsync(p => p.Id == programmingLanguageId);
            if (result==null)
            {
                throw new BusinessException("ProgrammingLanguage Id is not found!");
            }
        }

        public async Task ShouldHaveValidId(int technologyId)
        {
            Domain.Entities.Technology? result = await _technologyRepository.GetAsync(t => t.Id == technologyId);
            if (result == null)
            {
                throw new BusinessException("Technology's Id is not found!");
            }
        }

        public void TechnologyShouldExistWhenRequested(Domain.Entities.Technology? technology)
        {
            if (technology == null) throw new BusinessException("Requested technology does not exists");
        }
    }
}
