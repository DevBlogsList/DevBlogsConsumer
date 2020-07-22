using DevBlogsConsumer.Repositories.Contracts;
using System.Collections.Generic;

namespace DevBlogsConsumer.Repositories.Interfaces
{
    public interface IBlogRepository
    {
        IEnumerable<Blog> GetBlogs();
    }
}
