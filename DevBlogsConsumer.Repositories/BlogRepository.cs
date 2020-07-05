using DevBlogsConsumer.Repositories.Contracts;
using DevBlogsConsumer.Repositories.Interfaces;
using MongoDB.Driver;
using System.Threading.Tasks;

namespace DevBlogsConsumer.Repositories
{
    public class BlogRepository : IBlogRepository
    {
        private IMongoCollection<Blog> _blogCollection;

        public BlogRepository(IMongoCollection<Blog> blogCollection)
        {
            _blogCollection = blogCollection;
        }

        public Task<IAsyncCursor<Blog>> GetBlogs()
        {
            FilterDefinition<Blog> filterDefinition = Builders<Blog>.Filter.Empty;

            return _blogCollection.FindAsync(filterDefinition);
        }
    }
}
