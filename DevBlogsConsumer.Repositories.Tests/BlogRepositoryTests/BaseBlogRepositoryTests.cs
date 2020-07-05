using DevBlogsConsumer.Repositories.Contracts;
using DevBlogsConsumer.Repositories.Interfaces;
using MongoDB.Driver;
using Moq;

namespace DevBlogsConsumer.Repositories.Tests.BlogRepositoryTests
{
    public abstract class BaseBlogRepositoryTests
    {
        public const string TEST_CATEGORY = "Blog Repository Tests";

        public Mock<IMongoCollection<Blog>> _mockBlogCollection;
        public IBlogRepository _blogRepository;
    }
}
