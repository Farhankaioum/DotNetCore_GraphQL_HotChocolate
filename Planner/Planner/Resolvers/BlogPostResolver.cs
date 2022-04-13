using HotChocolate.Resolvers;
using Planner.Models;
using Planner.Repositories;

namespace Planner.Resolvers
{
    public class BlogPostResolver
    {
        private readonly IBlogPostRepository _blogPostRepository;

        public BlogPostResolver([Service] IBlogPostRepository blogPostRepository)
        {
            _blogPostRepository = blogPostRepository;
        }

        public IEnumerable<BlogPost> GetBlogPosts([Parent] Author author, IResolverContext ctx)
        {
            return _blogPostRepository.GetBlogPosts().Where(b => b.AuthorId == author.Id);
        }
    }
}
