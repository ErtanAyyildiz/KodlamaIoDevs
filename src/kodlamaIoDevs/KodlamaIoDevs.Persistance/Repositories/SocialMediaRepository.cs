using Core.Persistence.Repositories;
using KodlamaIoDevs.Application.Services.Repositorties;
using KodlamaIoDevs.Domain.Entities;
using KodlamaIoDevs.Persistance.Contexts;

namespace KodlamaIoDevs.Persistance.Repositories
{
    public class SocialMediaRepository : EfRepositoryBase<SocialMedia, BaseDbContext>, ISocialMediaRepository
    {
        public SocialMediaRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
