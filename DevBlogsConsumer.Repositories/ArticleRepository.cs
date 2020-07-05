using Dawn;
using DevBlogsConsumer.Repositories.Contracts;
using DevBlogsConsumer.Repositories.Interfaces;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        public Task<IAsyncCursor<string>> GetArticleIdsForBlog(string blogId)
        {
            Guard.Argument(blogId, nameof(blogId)).NotNull().NotEmpty();

            FilterDefinition<Article> filterDefinition = Builders<Article>.Filter.Eq(x => x.BlogId, blogId);
            ProjectionDefinition<Article> projectionDefinition = Builders<Article>.Projection.Include(x => x.ArticleId);
            FindOptions<Article, string> findOptions = new FindOptions<Article, string> { Projection = projectionDefinition };

            return _articleCollection.FindAsync(filterDefinition, findOptions);
        }
    }
}
