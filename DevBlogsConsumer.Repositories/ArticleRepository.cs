using Dawn;
using DevBlogsConsumer.Repositories.Contracts;
using DevBlogsConsumer.Repositories.Interfaces;
using MongoDB.Driver;
using System.Collections.Generic;

namespace DevBlogsConsumer.Repositories
{
    public class ArticleRepository : IArticleRepository
    {
        private IMongoCollection<Article> _articleCollection;

        public ArticleRepository(IMongoCollection<Article> articleCollection)
        {
            _articleCollection = articleCollection;
        }

        public void InsertArticles(IEnumerable<Article> articles)
        {
            Guard.Argument(articles, nameof(articles)).NotNull().NotEmpty();

            _articleCollection.InsertMany(articles);
        }
    }
}
