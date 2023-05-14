using BookStore.Domain.Models;

namespace BookStore.Infrastructure.Contracts
{
    public interface IBookRepository<TKey> : IBaseRepository<Book, TKey> { }
}