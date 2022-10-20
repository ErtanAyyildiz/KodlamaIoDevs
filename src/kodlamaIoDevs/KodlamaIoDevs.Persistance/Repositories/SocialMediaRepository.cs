using Core.Persistence.Repositories;
using KodlamaIoDevs.Application.Services.Repositories;
using KodlamaIoDevs.Domain.Entities;
using KodlamaIoDevs.Persistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaIoDevs.Persistance.Repositories
{
    public class SocialMediaRepository : EfRepositoryBase<SocialMedia, BaseDbContext>, ISocialMediaRepository
    {
        public SocialMediaRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
