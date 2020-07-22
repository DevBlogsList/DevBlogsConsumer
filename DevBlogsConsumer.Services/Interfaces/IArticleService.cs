using DevBlogsConsumer.Repositories.Contracts;
using System.Collections.Generic;

namespace DevBlogsConsumer.Services.Interfaces
{
    public interface IArticleService
    {
        void InsertArticlesForBlog(string blogId, IEnumerable<Article> articles);
    }
}
