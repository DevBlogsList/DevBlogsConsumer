using DevBlogsConsumer.Repositories.Contracts;
using DevBlogsConsumer.Repositories.Interfaces;
using DevBlogsConsumer.Services.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDB.Bson;
using MongoDB.Driver;
using Moq;
using System;
using System.Collections.Generic;

namespace DevBlogsConsumer.Services.Tests.ArticleServiceTests
{
    [TestCategory(TEST_CATEGORY)]
    [TestClass]
    public class InsertArticlesForBlogTests : BaseArticleServiceTests
    {
        private Mock<IArticleRepository> _mockArticleRepository;
        private IArticleService _articleService;
        private IEnumerable<Article> _articles;
        private IEnumerable<string> _articlesForBlogInDb;

        private const string BLOG_ID = "www.kiltandcode.com";

        [TestInitialize]
        public void Initialize()
        {
            _mockArticleRepository = new Mock<IArticleRepository>();
            _articleService = new ArticleService(_mockArticleRepository.Object);

            _articles = new List<Article>()
            {
                new Article
                {
                    Id = string.Empty,
                    BlogId = string.Empty,
                    ArticleId = "https://kiltandcode.com/2020/06/07/how-to-create-an-angular-9-app-from-scratch",
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
                },
                new Article
                {
                    Id = string.Empty,
                    BlogId = string.Empty,
                    ArticleId = "https://kiltandcode.com/2020/06/13/delete-unused-images-from-a-jekyll-website-using-powershell",
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

            _articlesForBlogInDb = new List<string>
            {
                "https://kiltandcode.com/2020/06/19/the-journey-has-begun-collaborating-on-a-new-open-source-project",
                "https://kiltandcode.com/2020/06/13/delete-unused-images-from-a-jekyll-website-using-powershell"
            };

            _mockArticleRepository
                .Setup(x => x.GetArticleIdsForBlog(It.IsAny<string>()))
                .Returns(() => _articlesForBlogInDb);

            _mockArticleRepository
                .Setup(x => x.RemoveDuplicatesByArticleId(_articles, _articlesForBlogInDb))
                .Returns(() => _articles);
        }

        [TestMethod]
        public void InsertArticlesForBlog_DoesNotThrowException()
        {
            _articleService.InsertArticlesForBlog(BLOG_ID, _articles);

            _mockArticleRepository.Verify(
                x => x.GetArticleIdsForBlog(BLOG_ID), Times.Once);

            _mockArticleRepository.Verify(
                x => x.RemoveDuplicatesByArticleId(
                    _articles, _articlesForBlogInDb), Times.Once);

            _mockArticleRepository.Verify(
                x => x.InsertArticles(_articles));
        }

        [TestMethod]
        public void InsertArticlesForBlog_WillSkipInsertIfNoArticles()
        {
            // TODO: Insert unit test functionality
        }

        [TestMethod]
        public void InsertArticlesForBlog_DoesNowAllowNullBlogId()
        {
            // TODO: Insert unit test functionality
        }

        [TestMethod]
        public void InsertArticlesForBlog_DoesNowAllowEmptyBlogId()
        {
            // TODO: Insert unit test functionality
        }

        [TestMethod]
        public void InsertArticlesForBlog_DoesNowAllowNullArticles()
        {
            // TODO: Insert unit test functionality
        }

        [TestMethod]
        public void InsertArticlesForBlog_DoesNowAllowEmptyArticles()
        {
            // TODO: Insert unit test functionality
        }
    }
}
