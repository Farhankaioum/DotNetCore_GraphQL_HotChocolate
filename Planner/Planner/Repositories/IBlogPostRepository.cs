using Planner.Models;

namespace Planner.Repositories
{
    public interface IBlogPostRepository
    {
        public List<BlogPost> GetBlogPosts();
        public BlogPost GetBlogPostById(int id);
    }
}
