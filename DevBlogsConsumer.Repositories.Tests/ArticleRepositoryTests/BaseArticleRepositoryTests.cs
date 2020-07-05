using DevBlogsConsumer.Repositories.Contracts;
using DevBlogsConsumer.Repositories.Interfaces;
using MongoDB.Driver;
using Moq;

namespace DevBlogsConsumer.Repositories.Tests.ArticleRepositoryTests
{
    public abstract class BaseArticleRepositoryTests
    {
        #region Constants

        public const string TEST_CATEGORY = "Article Repository Tests";
        public const string BLOG_ID = "www.kiltandcode.com";

        #endregion

        #region Properties

        public Mock<IMongoCollection<Article>> _mockArticleCollection;
        public IArticleRepository _articleRepository;

        #endregion
    }
}
