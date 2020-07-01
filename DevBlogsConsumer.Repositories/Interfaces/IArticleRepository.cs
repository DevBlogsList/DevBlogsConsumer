using DevBlogsConsumer.Repositories.Contracts;
using System.Collections.Generic;

namespace DevBlogsConsumer.Repositories.Interfaces
{
    public interface IArticleRepository
    {
        void InsertArticles(IEnumerable<Article> articles);
    }
}