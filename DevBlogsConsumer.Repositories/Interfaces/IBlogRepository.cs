using DevBlogsConsumer.Repositories.Contracts;
using MongoDB.Driver;
using System.Threading.Tasks;

namespace DevBlogsConsumer.Repositories.Interfaces
{
    public interface IBlogRepository
    {
        Task<IAsyncCursor<Blog>> GetBlogs();
    }
}
