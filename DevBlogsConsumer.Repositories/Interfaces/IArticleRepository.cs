using DevBlogsConsumer.Repositories.Contracts;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevBlogsConsumer.Repositories.Interfaces
{
    public interface IArticleRepository
    {
        void InsertArticles(IEnumerable<Article> articles);

        Task<IAsyncCursor<string>> GetArticleIdsForBlog(string blogId);
    }
}