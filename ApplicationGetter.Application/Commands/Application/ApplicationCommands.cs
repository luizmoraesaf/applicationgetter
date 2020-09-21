using ApplicationGetter.Application.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationGetter.Application.Commands.Application
{
    public sealed class ApplicationCommands : IApplicationCommands
    {
        private readonly IApplicationRepository applicationRepository;

        public ApplicationCommands(IApplicationRepository applicationRepository)
        {
            this.applicationRepository = applicationRepository;
        }

        public async Task<List<Domain.Application.Application>> ExecuteGetList()
        {
            List<Domain.Application.Application> applications = await applicationRepository.GetList();

            if (applications == null || applications.Count < 1)
                throw new ApplicationsListNotFoundException("There is no application in the database.");

            return applications;
        }

        public async Task<Domain.Application.Application> ExecuteGet(int id)
        {
            Domain.Application.Application application = await applicationRepository.Get(id);

            if (application == null)
                throw new ApplicationNotFoundException("There is no application with this id.");

            return application;
        }

        public async Task ExecuteAdd(Domain.Application.Application application)
        {
            await applicationRepository.Add(application);
        }

        public async Task ExecuteUpdate(Domain.Application.Application application)
        {
            await applicationRepository.Update(application);
        }

        public async Task ExecuteDelete(Domain.Application.Application application)
        {
            await applicationRepository.Delete(application);
        }
    }
}
