using DevBlogsConsumer.Repositories.Contracts;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevBlogsConsumer.Repositories.Interfaces
{
    public interface IArticleRepository
    {
        void InsertArticlesForBlog(string blogId, IEnumerable<Article> articles);

        Task<IAsyncCursor<Article>> GetArticlesForBlog(string blogId);
    }
}