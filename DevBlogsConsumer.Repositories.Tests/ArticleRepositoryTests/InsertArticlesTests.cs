using DevBlogsConsumer.Repositories.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDB.Bson;
using MongoDB.Driver;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace DevBlogsConsumer.Repositories.Tests.ArticleRepositoryTests
{
    [TestCategory(TEST_CATEGORY)]
    [TestClass]
    public class InsertArticlesTests : BaseArticleRepositoryTests
    {
        private IEnumerable<Article> _articles;

        [TestInitialize]
        public void Initialize()
        {
            _mockArticleCollection = new Mock<IMongoCollection<Article>>();
            _articleRepository = new ArticleRepository(_mockArticleCollection.Object);
            _articles = new List<Article>()
            {
                new Article
                {
                    Id = string.Empty,
                    BlogId = string.Empty,
                    ArticleId = string.Empty,
                    Title = string.Empty,
                    Link = string.Empty,
                    Published = new BsonDateTime(DateTime.Now),
                    LastUpdated = new BsonDateTime(DateTime.Now),
                    Author = new string[] { string.Empty },
                    Content = string.Empty,
                    Summary = string.Empty,
                    Thumbnail = string.Empty,
                    Image = string.Empty,
                    Category = new string[] { string.Empty },
                    Contributer = new string[] { string.Empty }
                }
            };

            _mockArticleCollection
                .Setup(x => x.InsertManyAsync(
                    _articles,
                    It.IsAny<InsertManyOptions>(),
                    It.IsAny<CancellationToken>()));
        }

        [TestMethod]
        public void InsertArticles_DoesNotThrowException()
        {
            _articleRepository.InsertArticles(_articles);

            _mockArticleCollection.Verify(
                x => x.InsertMany(
                    _articles,
                    It.IsAny<InsertManyOptions>(),
                    It.IsAny<CancellationToken>()
                ), Times.Once);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "articles cannot be null. (Parameter 'articles')")]
        public void InsertArticles_DoesNotAllowNullArticles()
        {
            _articles = null;

            _articleRepository.InsertArticles(_articles);

            _mockArticleCollection.Verify(
                x => x.InsertManyAsync(
                    _articles,
                    It.IsAny<InsertManyOptions>(),
                    It.IsAny<CancellationToken>()
                ), Times.Never);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "articles cannot be empty. (Parameter 'articles')")]
        public void InsertArticles_DoesNotAllowEmptyArticles()
        {
            _articles = Enumerable.Empty<Article>();

            _articleRepository.InsertArticles(_articles);

            _mockArticleCollection.Verify(
                x => x.InsertManyAsync(
                    _articles,
                    It.IsAny<InsertManyOptions>(),
                    It.IsAny<CancellationToken>()
                ), Times.Never);
        }
    }
}
