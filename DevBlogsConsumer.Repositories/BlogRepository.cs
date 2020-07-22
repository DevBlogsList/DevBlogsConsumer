using DevBlogsConsumer.Repositories.Contracts;
using DevBlogsConsumer.Repositories.Interfaces;
using MongoDB.Driver;
using System.Collections.Generic;

namespace DevBlogsConsumer.Repositories
{
    public class BlogRepository : IBlogRepository
    {
        private IMongoCollection<Blog> _blogCollection;

        public BlogRepository(IMongoCollection<Blog> blogCollection)
        {
            _blogCollection = blogCollection;
        }

        public IEnumerable<Blog> GetBlogs()
        {
            FilterDefinition<Blog> filterDefinition = Builders<Blog>.Filter.Empty;

            IAsyncCursor<Blog> blogs = _blogCollection.FindAsync(filterDefinition).Result;

            return blogs?.ToEnumerable();
        }
    }
}
