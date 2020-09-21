using ApplicationGetter.Domain.ValueObjects;
using MongoDB.Bson.Serialization.Attributes;

namespace ApplicationGetter.Domain.Application
{
    public sealed class Application: IEntity
    {
        [BsonId]
        public int Id { get; private set; }
        public Url Url { get; private set; }
        public PathLocal PathLocal { get; private set; }
        public bool DebuggingMode { get; private set; }

        public Application(Url url, PathLocal pathLocal, bool debuggingMode)
        {
            Url = url;
            PathLocal = pathLocal;
            DebuggingMode = debuggingMode;
        }

        public Application(int id, string url, string pathLocal, bool debuggingMode)
        {
            Id = id;
            Url = url;
            PathLocal = pathLocal;
            DebuggingMode = debuggingMode;
        }

        private Application() { }

        public static Application Load(int id, Url url, PathLocal pathLocal, bool debuggingMode)
        {
            Application application = new Application();
            application.Id = id;
            application.Url = url;
            application.PathLocal = pathLocal;
            application.DebuggingMode = debuggingMode;
            return application;
        }
    }
}
