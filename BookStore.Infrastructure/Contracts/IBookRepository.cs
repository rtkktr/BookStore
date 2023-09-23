using BookStore.Domain.Models.BookAggregates;

namespace BookStore.Infrastructure.Contracts
{
    public interface IBookRepository : ICompleteBaseRepository<Book> { }
}