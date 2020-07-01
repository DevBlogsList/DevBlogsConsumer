using DevBlogsConsumer.Repositories.Contracts;
using DevBlogsConsumer.Repositories.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDB.Driver;
using Moq;
using Shouldly;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DevBlogsConsumer.Repositories.Tests.BlogRepositoryTests
{
    [TestCategory(TEST_CATEGORY)]
    [TestClass]
    public class GetBlogsTests : BaseBlogRepositoryTests
    {
        private IAsyncCursor<Blog> _blogs;
        private Mock<IMongoCollection<Blog>> _mockBlogCollection;
        private IBlogRepository _blogRepository;

        [TestInitialize]
        public void Initialize()
        {
            _mockBlogCollection = new Mock<IMongoCollection<Blog>>();
            _blogRepository = new BlogRepository(_mockBlogCollection.Object);

            _blogs = Enumerable.Empty<Blog>() as IAsyncCursor<Blog>;

            _mockBlogCollection
                .Setup(x => x.FindAsync(
                    It.IsAny<FilterDefinition<Blog>>(),
                    It.IsAny<FindOptions<Blog, Blog>>(),
                    It.IsAny<CancellationToken>()
                ))
                .ReturnsAsync(() => _blogs);
        }

        [TestMethod]
        public async Task GetBlogs_ReturnsBlogs()
        {
            IAsyncCursor<Blog> blogs = await _blogRepository.GetBlogs();

            _mockBlogCollection.Verify(
                x => x.FindAsync(
                    It.IsAny<FilterDefinition<Blog>>(),
                    It.IsAny<FindOptions<Blog, Blog>>(),
                    It.IsAny<CancellationToken>()
                ), Times.Once);

            blogs.ShouldBeSameAs(_blogs);
        }
    }
}
