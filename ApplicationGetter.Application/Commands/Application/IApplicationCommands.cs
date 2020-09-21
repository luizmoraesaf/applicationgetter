using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationGetter.Application.Commands.Application
{
    public interface IApplicationCommands
    {
        Task<List<Domain.Application.Application>> ExecuteGetList();
        Task<Domain.Application.Application> ExecuteGet(int id);
        Task ExecuteAdd(Domain.Application.Application application);
        Task ExecuteUpdate(Domain.Application.Application application);
        Task ExecuteDelete(Domain.Application.Application application);
    }
}
