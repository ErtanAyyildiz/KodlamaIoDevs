using Core.Persistence.Repositories;
using Core.Security.Entities;

namespace KodlamaIoDevs.Application.Services.Repositorties
{
    public interface IUserRepository: IAsyncRepository<User>, IRepository<User>
    {
    }
}
