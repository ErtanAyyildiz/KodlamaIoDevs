using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using KodlamaIoDevs.Application.Services.Repositorties;

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

        public async Task NameCanNotBeDuplicatedWhenInserted(string name)
        {
            IPaginate<Domain.Entities.Technology> result = await _technologyRepository.GetListAsync(f => f.Name == name);

            if (result.Items.Any())
                throw new BusinessException("Technology's name exists!");
        }

        public async Task ShouldHaveValidForeignKey(int programmingLanguageId)
        {
            Domain.Entities.ProgrammingLanguage? result = await _programmingLanguageRepository.GetAsync(p => p.Id == programmingLanguageId);

            if (result == null)
                throw new BusinessException("ProgrammingLanguage Id is not found!");
        }

        public async Task ShouldHaveValidId(int technologyId)
        {
            Domain.Entities.Technology? result = await _technologyRepository.GetAsync(p => p.Id == technologyId);

            if (result == null)
                throw new BusinessException("Technology's Id is not found!");
        }

        public void TechnologyShouldExistWhenRequested(Domain.Entities.Technology? technology)
        {
            if (technology == null) throw new BusinessException("Requested technology does not exists");
        }

    }
}
