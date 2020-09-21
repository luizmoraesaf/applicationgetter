using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace ApplicationGetter.Infrastructure.MongoDataAccess
{
    public class Context
    {
        private readonly MongoClient mongoClient;
        private readonly IMongoDatabase database;

        public Context()
        {
            mongoClient = new MongoClient(@"mongodb+srv://admin:admin123@cluster0.ns4uk.mongodb.net/test");
            database = mongoClient.GetDatabase("applicationsDB");
            Map();
        }

        public IMongoCollection<Domain.Application.Application> Applications
        {
            get
            {
                return database.GetCollection<Domain.Application.Application>("Application");
            }
        }

        private void Map()
        {
            BsonClassMap.RegisterClassMap<Domain.Application.Application>(cm =>
            {
                cm.MapIdProperty(app => app.Id);
                cm.MapProperty(app => app.Url);
                cm.MapProperty(app => app.PathLocal);
                cm.MapProperty(app => app.DebuggingMode);
                cm.MapCreator(app => new Domain.Application.Application(app.Id, app.Url, app.PathLocal, app.DebuggingMode));
            });
        }
    }
}
