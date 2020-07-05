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
    public class InsertArticlesForBlogTests : BaseArticleRepositoryTests
    {
        private string _blogId;
        private IEnumerable<Article> _articles;

        [TestInitialize]
        public void Initialize()
        {
            _mockArticleCollection = new Mock<IMongoCollection<Article>>();
            _articleRepository = new ArticleRepository(_mockArticleCollection.Object);
            _blogId = BLOG_ID;
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
        public void InsertArticlesForBlog_DoesNotThrowException()
        {
            _articleRepository.InsertArticlesForBlog(_blogId, _articles);

            _mockArticleCollection.Verify(
                x => x.InsertMany(
                    _articles,
                    It.IsAny<InsertManyOptions>(),
                    It.IsAny<CancellationToken>()
                ), Times.Once);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "blogId cannot be null. (Parameter 'blogId')")]
        public void InsertArticlesForBlog_DoesNotAllowNullBlogId()
        {
            _blogId = null;

            _articleRepository.InsertArticlesForBlog(_blogId, _articles);

            // TODO: Replace with the functionality for comparing articles already in the database
            _mockArticleCollection.Verify(
                x => x.InsertManyAsync(
                    _articles,
                    It.IsAny<InsertManyOptions>(),
                    It.IsAny<CancellationToken>()
                ), Times.Never);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "blogId cannot be empty. (Parameter 'blogId')")]
        public void InsertArticlesForBlog_DoesNotAllowEmptyBlogId()
        {
            _blogId = string.Empty;

            _articleRepository.InsertArticlesForBlog(_blogId, _articles);

            // TODO: Replace with the functionality for comparing articles already in the database
            _mockArticleCollection.Verify(
                x => x.InsertManyAsync(
                    _articles,
                    It.IsAny<InsertManyOptions>(),
                    It.IsAny<CancellationToken>()
                ), Times.Never);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "articles cannot be null. (Parameter 'articles')")]
        public void InsertArticlesForBlog_DoesNotAllowNullArticles()
        {
            _articles = null;

            _articleRepository.InsertArticlesForBlog(_blogId, _articles);

            // TODO: Replace with the functionality for comparing articles already in the database
            _mockArticleCollection.Verify(
                x => x.InsertManyAsync(
                    _articles,
                    It.IsAny<InsertManyOptions>(),
                    It.IsAny<CancellationToken>()
                ), Times.Never);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "articles cannot be empty. (Parameter 'articles')")]
        public void InsertArticlesForBlog_DoesNotAllowEmptyArticles()
        {
            _articles = Enumerable.Empty<Article>();

            _articleRepository.InsertArticlesForBlog(_blogId, _articles);

            // TODO: Replace with the functionality for comparing articles already in the database
            _mockArticleCollection.Verify(
                x => x.InsertManyAsync(
                    _articles,
                    It.IsAny<InsertManyOptions>(),
                    It.IsAny<CancellationToken>()
                ), Times.Never);
        }
    }
}
