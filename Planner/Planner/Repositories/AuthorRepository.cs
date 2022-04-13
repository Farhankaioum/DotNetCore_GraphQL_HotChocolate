using Microsoft.EntityFrameworkCore;
using Planner.Data;
using Planner.Models;

namespace Planner.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly IDbContextFactory<ApplicationDbContext> _dbContextFactory;
        public AuthorRepository(IDbContextFactory<ApplicationDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
            using (var _applicationDbContext = _dbContextFactory.CreateDbContext())
            {
                _applicationDbContext.Database.EnsureCreated();
            }
        }
        public List<Author> GetAuthors()
        {
            using (var applicationDbContext =
                _dbContextFactory.CreateDbContext())
            {
                return applicationDbContext.Authors.ToList();
            }
        }
        public Author GetAuthorById(int id)
        {
            using (var applicationDbContext =
                _dbContextFactory.CreateDbContext())
            {
                return applicationDbContext.Authors.SingleOrDefault(x => x.Id == id);
            }
        }
        public async Task<Author> CreateAuthor(Author author)
        {
            using (var applicationDbContext =
                _dbContextFactory.CreateDbContext())
            {
                await applicationDbContext.Authors.AddAsync(author);
                await applicationDbContext.SaveChangesAsync();

                return author;
            }
        }

        public async Task<Author> UpdateAuthor(Author author)
        {
            using (var applicationDbContext =
                _dbContextFactory.CreateDbContext())
            {
                var existingAuthor = applicationDbContext.Authors.FirstOrDefault(x => x.Id == author.Id);

                if (existingAuthor == null)
                    throw new NullReferenceException(nameof(Author));

                    existingAuthor.FirstName = author.FirstName;
                    existingAuthor.LastName = author.LastName;

                    applicationDbContext.Authors.Update(existingAuthor);
                    await applicationDbContext.SaveChangesAsync();

                return author;
            }
        }

        public async Task<Author> DeleteAuthor(int authorId)
        {
            using (var applicationDbContext =  _dbContextFactory.CreateDbContext())
            {
                var existingAuthor = await applicationDbContext.Authors.FirstOrDefaultAsync(x => x.Id == authorId);

                if(existingAuthor != null)
                {
                    applicationDbContext.Authors.Remove(existingAuthor);
                    await applicationDbContext.SaveChangesAsync();
                }

                return existingAuthor;
            }
        }
    }
}
