using Dawn;
using DevBlogsConsumer.Repositories.Contracts;
using DevBlogsConsumer.Repositories.Interfaces;
using DevBlogsConsumer.Services.Interfaces;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace DevBlogsConsumer.Services
{
    public class ArticleService : IArticleService
    {
        private IArticleRepository _articleRepository;

        public ArticleService(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public void InsertArticlesForBlog(string blogId, IEnumerable<Article> articles)
        {
            Guard.Argument(blogId, nameof(blogId)).NotNull().NotEmpty();
            Guard.Argument(articles, nameof(articles)).NotNull().NotEmpty();

            // Retrieve the articles already in the database for the specified blog
            IEnumerable<string> articlesForBlogInDb = 
                _articleRepository.GetArticleIdsForBlog(blogId);

            // Remove any duplicate entries
            articles = _articleRepository.RemoveDuplicatesByArticleId(
                articles, articlesForBlogInDb);

            // Insert the new articles into the database
            if (articles.Any())
                _articleRepository.InsertArticles(articles);
        }


    }
}
