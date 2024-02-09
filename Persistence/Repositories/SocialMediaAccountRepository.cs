using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Core.Security.Entities;
using Domain.Entities;
using Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class SocialMediaAccountRepository : EfRepositoryBase<SocialMediaAccount, BaseDbContext>, ISocialMediaAccountRepository
    {
        public SocialMediaAccountRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
