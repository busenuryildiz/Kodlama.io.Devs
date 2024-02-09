using Core.Persistence.Repositories;
using Domain.Entities;

namespace Application.Services.Repositories
{
    public interface ISocialMediaAccountRepository:IAsyncRepository<SocialMediaAccount>,IRepository<SocialMediaAccount>
    {
    }


}
