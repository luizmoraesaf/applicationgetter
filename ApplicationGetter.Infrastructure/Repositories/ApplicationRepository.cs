using ApplicationGetter.Application.Repositories;
using ApplicationGetter.Infrastructure.MongoDataAccess;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationGetter.Infrastructure.Repositories
{
    public class ApplicationRepository : IApplicationRepository
    {
        private readonly Context _context;

        public ApplicationRepository()
        {
            _context = new Context();
        }

        public async Task<List<Domain.Application.Application>> GetList()
        {
            return await _context
               .Applications
               .Find(_ => true)
               .ToListAsync();
        }

        public async Task<Domain.Application.Application> Get(int id)
        {
            Domain.Application.Application application = await _context.Applications
                .Find(e => e.Id == id)
                .SingleOrDefaultAsync();

            return Domain.Application.Application.Load(application.Id, application.Url, application.PathLocal, application.DebuggingMode);
        }

        public async Task Add(Domain.Application.Application application)
        {
            await _context.Applications.InsertOneAsync(application);
        }

        public async Task Delete(Domain.Application.Application application)
        {
            await _context.Applications.DeleteOneAsync(e => e.Id == application.Id);
        }

        public async Task Update(Domain.Application.Application application)
        {
            await _context.Applications
                .ReplaceOneAsync(e => e.Id == application.Id, application);
        }
    }
}
