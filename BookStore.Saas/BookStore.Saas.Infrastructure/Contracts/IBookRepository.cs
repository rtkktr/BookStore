using BookStore.Saas.Domain.Models;

namespace BookStore.Saas.Infrastructure.Contracts
{
    public interface IBookRepository<TKey, TExist, TStatus> : IBaseRepository<Book?, TKey, TExist, TStatus> { }
}