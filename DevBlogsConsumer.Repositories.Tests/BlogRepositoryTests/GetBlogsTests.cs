using DevBlogsConsumer.Repositories.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDB.Driver;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace DevBlogsConsumer.Repositories.Tests.BlogRepositoryTests
{
    [TestCategory(TEST_CATEGORY)]
    [TestClass]
    public class GetBlogsTests : BaseBlogRepositoryTests
    {
        private IAsyncCursor<Blog> _blogs;

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
        public void GetBlogs_ReturnsBlogs()
        {
            IEnumerable<Blog> blogs = _blogRepository.GetBlogs();

            _mockBlogCollection.Verify(
                x => x.FindAsync(
                    It.IsAny<FilterDefinition<Blog>>(),
                    It.IsAny<FindOptions<Blog, Blog>>(),
                    It.IsAny<CancellationToken>()
                ), Times.Once);
        }
    }
}
