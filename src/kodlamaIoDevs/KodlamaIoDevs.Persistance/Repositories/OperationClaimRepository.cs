using Core.Persistence.Repositories;
using Core.Security.Entities;
using KodlamaIoDevs.Application.Services.Repositories;
using KodlamaIoDevs.Persistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaIoDevs.Persistance.Repositories
{
    public class OperationClaimRepository : EfRepositoryBase<OperationClaim, BaseDbContext>, IOperationClaimRepository
    {
        //deneme
        public OperationClaimRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
