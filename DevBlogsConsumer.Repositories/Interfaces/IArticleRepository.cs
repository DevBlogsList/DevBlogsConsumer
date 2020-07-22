using DevBlogsConsumer.Repositories.Contracts;
using System.Collections.Generic;

namespace DevBlogsConsumer.Repositories.Interfaces
{
    public interface IArticleRepository
    {
        void InsertArticles(IEnumerable<Article> articles);
        IEnumerable<string> GetArticleIdsForBlog(string blogId);
        IEnumerable<Article> RemoveDuplicatesByArticleId(IEnumerable<Article> articles, IEnumerable<string> articlesForBlogInDb);
    }
}