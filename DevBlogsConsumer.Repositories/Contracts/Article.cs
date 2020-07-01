using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;

namespace DevBlogsConsumer.Repositories.Contracts
{
    public class Article
    {
        [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        public string Id { get; set; }

        [BsonElement("blogid")]
        public string BlogId { get; set; }

        [BsonElement("articleid")]
        public string ArticleId { get; set; }

        [BsonElement("title")]
        public string Title { get; set; }

        [BsonElement("link")]
        public string Link { get; set; }

        [BsonElement("published")]
        public BsonDateTime Published { get; set; }

        [BsonElement("lastupdated")]
        public BsonDateTime LastUpdated { get; set; }

        [BsonElement("author")]
        public string[] Author { get; set; }

        [BsonElement("content")]
        public string Content { get; set; }

        [BsonElement("summary")]
        public string Summary { get; set; }

        [BsonElement("thumbnail")]
        public string Thumbnail { get; set; }

        [BsonElement("image")]
        public string Image { get; set; }

        [BsonElement("category")]
        public string[] Category { get; set; }

        [BsonElement("contributer")]
        public string[] Contributer { get; set; }
    }
}
