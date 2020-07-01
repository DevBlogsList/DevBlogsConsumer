using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;

namespace DevBlogsConsumer.Repositories.Contracts
{
    public class Blog
    {
        [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        public string Id { get; set; }

        [BsonElement("blogid")]
        public string BlogId { get; set; }

        [BsonElement("title")]
        public string Title { get; set; }

        [BsonElement("subtitle")]
        public string Subtitle { get; set; }

        [BsonElement("author")]
        public string[] Author { get; set; }

        [BsonElement("link")]
        public string Link { get; set; }

        [BsonElement("feed")]
        public Feed Feed { get; set; }

        [BsonElement("category")]
        public string[] Category { get; set; }

        [BsonElement("icon")]
        public string Icon { get; set; }

        [BsonElement("logo")]
        public string Logo { get; set; }

        [BsonElement("active")]
        public bool IsActive { get; set; }

        [BsonElement("created")]
        public BsonDateTime Created { get; set; }
    }
}
