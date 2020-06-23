using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;

namespace DevBlogsConsumer.Repositories.Contracts
{
    public class Blog
    {
        [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        public string Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("url")]
        public string Url { get; set; }

        [BsonElement("feed")]
        public string Feed { get; set; }

        [BsonElement("active")]
        public bool IsActive { get; set; }

        [BsonElement("created")]
        public BsonDateTime Created { get; set; }
    }
}
