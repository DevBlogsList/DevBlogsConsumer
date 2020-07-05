using Dawn;
using DevBlogsConsumer.Repositories.Contracts;
using DevBlogsConsumer.Repositories.Interfaces;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace DevBlogsConsumer.Services
{
    public class ArticleService
    {
        private IArticleRepository _articleRepository;

        public ArticleService(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public void InsertArticlesForBlog(string blogId, IEnumerable<Article> articles)
        {
            Guard.Argument(blogId, nameof(blogId)).NotNull().NotEmpty();
            Guard.Argument(blogId, nameof(articles)).NotNull().NotEmpty();

            // Retrieve the articles already in the database for the specified blog
            IEnumerable<string> articlesForBlogInDatabase =
                _articleRepository.GetArticleIdsForBlog(blogId).Result.ToList();

            // Remove any duplicate entries
            if (articlesForBlogInDatabase.Any())
                articles = articles.Where(x => !articlesForBlogInDatabase.Contains(x.ArticleId));

            // Insert the new articles into the database
            if (articles.Any())
                _articleRepository.InsertArticles(articles);
        }
    }
}
