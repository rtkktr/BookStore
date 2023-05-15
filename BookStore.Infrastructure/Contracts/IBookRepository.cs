using BookStore.Domain.Models;

namespace BookStore.Infrastructure.Contracts
{
    public interface IBookRepository<TKey, TExist> : IBaseRepository<Book?, TKey, TExist> { }
}