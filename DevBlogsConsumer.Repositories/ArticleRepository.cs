using Dawn;
using DevBlogsConsumer.Repositories.Contracts;
using DevBlogsConsumer.Repositories.Interfaces;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

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

        public IEnumerable<string> GetArticleIdsForBlog(string blogId)
        {
            Guard.Argument(blogId, nameof(blogId)).NotNull().NotEmpty();

            FilterDefinition<Article> filterDefinition = Builders<Article>.Filter.Eq(x => x.BlogId, blogId);
            ProjectionDefinition<Article> projectionDefinition = Builders<Article>.Projection.Include(x => x.ArticleId);
            FindOptions<Article, string> findOptions = new FindOptions<Article, string> { Projection = projectionDefinition };

            IAsyncCursor<string> articles = _articleCollection.FindAsync(filterDefinition, findOptions).Result;

            return articles?.ToEnumerable();
        }

        public IEnumerable<Article> RemoveDuplicatesByArticleId(
            IEnumerable<Article> articles,
            IEnumerable<string> articleIds)
        {
            Guard.Argument(articles, nameof(articles)).NotNull().NotEmpty();
            Guard.Argument(articleIds, nameof(articleIds)).NotNull().NotEmpty();

            return articles.Where(x => !articleIds.Contains(x.ArticleId));
        }
    }
}
