using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationGetter.Application.Repositories
{
    public interface IApplicationRepository
    {
        Task<List<Domain.Application.Application>> GetList();
        Task<Domain.Application.Application> Get(int id);
        Task Add(Domain.Application.Application application);
        Task Update(Domain.Application.Application application);
        Task Delete(Domain.Application.Application application);
    }
}
