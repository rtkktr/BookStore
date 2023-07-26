using BookStore.Domain.Models;

namespace BookStore.Infrastructure.Contracts
{
    public interface IBookRepository<TKey, TExist, TStatus> : IBaseRepository<Book?, TKey, TExist, TStatus> { }
}