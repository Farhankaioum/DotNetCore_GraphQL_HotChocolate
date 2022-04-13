using HotChocolate.Resolvers;
using Planner.Models;
using Planner.Repositories;

namespace Planner.Resolvers
{
    public class AuthorResolver
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorResolver([Service] IAuthorRepository
        authorService)
        {
            _authorRepository = authorService;
        }

        public Author GetAuthor(BlogPost blog, IResolverContext ctx)
        {
            return _authorRepository.GetAuthors().Where
            (a => a.Id == blog.AuthorId).FirstOrDefault();
        }
    }
}
