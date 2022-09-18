using Core.Persistence.Repositories;
using KodlamaIoDevs.Domain.Entities;

namespace KodlamaIoDevs.Application.Services.Repositorties
{
    public interface ISocialMediaRepository: IAsyncRepository<SocialMedia>, IRepository<SocialMedia>
    {
    }
}
