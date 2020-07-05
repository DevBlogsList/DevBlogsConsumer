using DevBlogsConsumer.Repositories.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDB.Driver;
using Moq;
using Shouldly;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DevBlogsConsumer.Repositories.Tests.ArticleRepositoryTests
{
    [TestCategory(TEST_CATEGORY)]
    [TestClass]
    public class GetArticleIdsForBlogTests : BaseArticleRepositoryTests
    {
        private IAsyncCursor<string> _articleIds;
        private string _blogId;

        [TestInitialize]
        public void Initialize()
        {
            _mockArticleCollection = new Mock<IMongoCollection<Article>>();
            _articleRepository = new ArticleRepository(_mockArticleCollection.Object);
            _blogId = BLOG_ID;

            _articleIds = Enumerable.Empty<string>() as IAsyncCursor<string>;

            _mockArticleCollection
                .Setup(x => x.FindAsync(
                    It.IsAny<FilterDefinition<Article>>(),
                    It.IsAny<FindOptions<Article, string>>(),
                    It.IsAny<CancellationToken>()
                ))
                .ReturnsAsync(() => _articleIds);
        }

        [TestMethod]
        public async Task GetArticleIdsForBlog_ReturnsArticleIdsForBlog()
        {
            IAsyncCursor<string> articleIds = await _articleRepository.GetArticleIdsForBlog(_blogId);

            _mockArticleCollection.Verify(
                x => x.FindAsync(
                    It.IsAny<FilterDefinition<Article>>(),
                    It.IsAny<FindOptions<Article, string>>(),
                    It.IsAny<CancellationToken>()
                ), Times.Once);

            articleIds.ShouldBeSameAs(_articleIds);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "blogId cannot be null. (Parameter 'blogId')")]
        public async Task GetArticleIdsForBlog_DoesNotAllowNullBlogId()
        {
            _blogId = null;

            IAsyncCursor<string> articleIds = await _articleRepository.GetArticleIdsForBlog(_blogId);

            _mockArticleCollection.Verify(
                x => x.FindAsync(
                    It.IsAny<FilterDefinition<Article>>(),
                    It.IsAny<FindOptions<Article, string>>(),
                    It.IsAny<CancellationToken>()
                ), Times.Never);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "blogId cannot be empty. (Parameter 'blogId')")]
        public async Task GetArticleIdsForBlog_DoesNotAllowEmptyBlogId()
        {
            _blogId = string.Empty;

            IAsyncCursor<string> articleIds = await _articleRepository.GetArticleIdsForBlog(_blogId);

            _mockArticleCollection.Verify(
                x => x.FindAsync(
                    It.IsAny<FilterDefinition<Article>>(),
                    It.IsAny<FindOptions<Article, string>>(),
                    It.IsAny<CancellationToken>()
                ), Times.Never);
        }
    }
}
