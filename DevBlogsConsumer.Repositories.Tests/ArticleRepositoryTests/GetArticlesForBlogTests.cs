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
    public class GetArticlesForBlogTests : BaseArticleRepositoryTests
    {
        private IAsyncCursor<Article> _articles;
        private string _blogId;

        [TestInitialize]
        public void Initialize()
        {
            _mockArticleCollection = new Mock<IMongoCollection<Article>>();
            _articleRepository = new ArticleRepository(_mockArticleCollection.Object);
            _blogId = BLOG_ID;

            _articles = Enumerable.Empty<Article>() as IAsyncCursor<Article>;

            _mockArticleCollection
                .Setup(x => x.FindAsync(
                    It.IsAny<FilterDefinition<Article>>(),
                    It.IsAny<FindOptions<Article, Article>>(),
                    It.IsAny<CancellationToken>()
                ))
                .ReturnsAsync(() => _articles);
        }

        [TestMethod]
        public async Task GetArticlesForBlog_ReturnsArticlesForBlog()
        {
            IAsyncCursor<Article> articles = await _articleRepository.GetArticlesForBlog(_blogId);

            _mockArticleCollection.Verify(
                x => x.FindAsync(
                    It.IsAny<FilterDefinition<Article>>(),
                    It.IsAny<FindOptions<Article, Article>>(),
                    It.IsAny<CancellationToken>()
                ), Times.Once);

            articles.ShouldBeSameAs(_articles);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "blogId cannot be null. (Parameter 'blogId')")]
        public async Task GetArticlesForBlog_DoesNotAllowNullBlogId()
        {
            _blogId = null;

            IAsyncCursor<Article> articles = await _articleRepository.GetArticlesForBlog(_blogId);

            _mockArticleCollection.Verify(
                x => x.FindAsync(
                    It.IsAny<FilterDefinition<Article>>(),
                    It.IsAny<FindOptions<Article, Article>>(),
                    It.IsAny<CancellationToken>()
                ), Times.Never);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "blogId cannot be empty. (Parameter 'blogId')")]
        public async Task GetArticlesForBlog_DoesNotAllowEmptyBlogId()
        {
            _blogId = string.Empty;

            IAsyncCursor<Article> articles = await _articleRepository.GetArticlesForBlog(_blogId);

            _mockArticleCollection.Verify(
                x => x.FindAsync(
                    It.IsAny<FilterDefinition<Article>>(),
                    It.IsAny<FindOptions<Article, Article>>(),
                    It.IsAny<CancellationToken>()
                ), Times.Never);
        }
    }
}
