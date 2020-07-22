using DevBlogsConsumer.Repositories.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDB.Driver;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading;

namespace DevBlogsConsumer.Repositories.Tests.ArticleRepositoryTests
{
    [TestCategory(TEST_CATEGORY)]
    [TestClass]
    public class GetArticleIdsForBlogTests : BaseArticleRepositoryTests
    {
        private string _blogId;

        [TestInitialize]
        public void Initialize()
        {
            _mockArticleCollection = new Mock<IMongoCollection<Article>>();
            _articleRepository = new ArticleRepository(_mockArticleCollection.Object);
            _blogId = BLOG_ID;
        }

        [TestMethod]
        public void GetArticleIdsForBlog_ReturnsArticleIdsForBlog()
        {
            IEnumerable<string> articleIds = _articleRepository.GetArticleIdsForBlog(_blogId);

            _mockArticleCollection.Verify(
                x => x.FindAsync(
                    It.IsAny<FilterDefinition<Article>>(),
                    It.IsAny<FindOptions<Article, string>>(),
                    It.IsAny<CancellationToken>()
                ), Times.Once);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "blogId cannot be null. (Parameter 'blogId')")]
        public void GetArticleIdsForBlog_DoesNotAllowNullBlogId()
        {
            _blogId = null;

            _articleRepository.GetArticleIdsForBlog(_blogId);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "blogId cannot be empty. (Parameter 'blogId')")]
        public void GetArticleIdsForBlog_DoesNotAllowEmptyBlogId()
        {
            _blogId = string.Empty;

            _articleRepository.GetArticleIdsForBlog(_blogId);
        }
    }
}
