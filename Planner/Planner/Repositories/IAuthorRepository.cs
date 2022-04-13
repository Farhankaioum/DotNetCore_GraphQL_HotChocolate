using Planner.Models;

namespace Planner.Repositories
{
    public interface IAuthorRepository
    {
        public List<Author> GetAuthors();
        public Author GetAuthorById(int id);
        public Task<Author> CreateAuthor(Author author);
        Task<Author> UpdateAuthor(Author author);
        public Task<Author> DeleteAuthor(int authorId);
    }
}
