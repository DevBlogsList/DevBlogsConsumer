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

        public void InsertArticlesForBlog(string blogId, IEnumerable<Article> articles)
        {
            Guard.Argument(blogId, nameof(blogId)).NotNull().NotEmpty();
            Guard.Argument(articles, nameof(articles)).NotNull().NotEmpty();

            // TODO: Add functionality to compare articles already in the database

            // TODO: Use bulk write statement for MongoDB to do insert and updates

            _articleCollection.InsertMany(articles);
        }

        public Task<IAsyncCursor<Article>> GetArticlesForBlog(string blogId)
        {
            Guard.Argument(blogId, nameof(blogId)).NotNull().NotEmpty();

            SortDefinition<Article> sortDefinition = Builders<Article>.Sort.Descending(x => x.Published);

            return _articleCollection.FindAsync(
                x => x.BlogId == blogId, new FindOptions<Article, Article>()
            {
                Sort = sortDefinition
            });
        }
    }
}
