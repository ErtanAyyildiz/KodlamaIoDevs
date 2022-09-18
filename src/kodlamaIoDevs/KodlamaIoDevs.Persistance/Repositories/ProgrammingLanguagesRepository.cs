using Core.Persistence.Repositories;
using KodlamaIoDevs.Application.Services.Repositorties;
using KodlamaIoDevs.Domain.Entities;
using KodlamaIoDevs.Persistance.Contexts;

namespace KodlamaIoDevs.Persistance.Repositories
{
    public class ProgrammingLanguagesRepository : EfRepositoryBase<ProgrammingLanguage, BaseDbContext>, IProgrammingLanguageRepository
    {
        public ProgrammingLanguagesRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
