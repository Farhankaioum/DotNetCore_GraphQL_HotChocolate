using Microsoft.EntityFrameworkCore;
using Planner.Data;
using Planner.Models;

namespace Planner.Repositories
{
    public class BlogPostRepository : IBlogPostRepository
    {
        private readonly IDbContextFactory<ApplicationDbContext> _dbContextFactory;

        public BlogPostRepository(IDbContextFactory
            <ApplicationDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;

            using (var applicationDbContext = _dbContextFactory.CreateDbContext())
            {
                applicationDbContext.Database.EnsureCreated();
            }
        }
        public List<BlogPost> GetBlogPosts()
        {
            using (var applicationDbContext = _dbContextFactory.CreateDbContext())
            {
                return applicationDbContext.BlogPosts.ToList();
            }
        }
        public BlogPost GetBlogPostById(int id)
        {
            using (var applicationDbContext =  _dbContextFactory.CreateDbContext())
            {
                return applicationDbContext.BlogPosts.SingleOrDefault(x => x.Id == id);
            }
        }
    }
}
