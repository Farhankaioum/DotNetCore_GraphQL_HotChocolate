using HotChocolate.Subscriptions;
using Planner.Models;
using Planner.Repositories;

namespace Planner.GraphQL
{
    public class Mutation
    {
        public async Task<Author> CreateAuthor([Service] IAuthorRepository authorRepository, [Service] ITopicEventSender eventSender, int id, string firstName, string lastName)
        {
            var data = new Author
            {
                Id = id,
                FirstName = firstName,
                LastName = lastName
            };

            var result = await authorRepository.CreateAuthor(data);
            await eventSender.SendAsync("AuthorCreated", result);

            return result;
        }

        public async Task<Author> UpdateAuthor([Service] IAuthorRepository authorRepository, [Service] ITopicEventSender eventSender, int id, string firstName, string lastName)
        {
            var data = new Author
            {
                Id = id,
                FirstName = firstName,
                LastName = lastName
            };

            var result = await authorRepository.UpdateAuthor(data);
            await eventSender.SendAsync("AuthorCreated", result);

            return result;
        }

        public async Task<Author> DeleteAuthor([Service] IAuthorRepository authorRepository, [Service] ITopicEventSender eventSender, int authorId)
        {
            var result = await authorRepository.DeleteAuthor(authorId);
            await eventSender.SendAsync("AuthorCreated", result);

            return result;
        }
    }
}