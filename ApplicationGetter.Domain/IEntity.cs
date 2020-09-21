using MongoDB.Bson.Serialization.Attributes;

namespace ApplicationGetter.Domain
{
    internal interface IEntity
    {
        [BsonId]
        int Id { get; }
    }
}
