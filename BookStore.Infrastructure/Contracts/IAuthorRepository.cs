using BookStore.Domain.Models.AuthorAggregates;

namespace BookStore.Infrastructure.Contracts
{
    public interface IAuthorRepository : ICompleteBaseRepository<Author> { }
}