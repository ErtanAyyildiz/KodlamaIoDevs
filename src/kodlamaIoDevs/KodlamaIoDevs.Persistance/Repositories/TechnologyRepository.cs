using Core.Persistence.Repositories;
using KodlamaIoDevs.Application.Services.Repositorties;
using KodlamaIoDevs.Domain.Entities;
using KodlamaIoDevs.Persistance.Contexts;

namespace KodlamaIoDevs.Persistance.Repositories
{
    public class TechnologyRepository : EfRepositoryBase<Technology, BaseDbContext>, ITechnologyRepository
    {
        public TechnologyRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
