using DevBlogsConsumer.Repositories.Enums;

namespace DevBlogsConsumer.Repositories.Contracts
{
    public class Feed
    {
        public string Link { get; set; }

        public FeedType Type { get; set; }
    }
}
