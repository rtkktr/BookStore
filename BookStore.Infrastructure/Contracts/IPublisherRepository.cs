using BookStore.Domain.Models;

namespace BookStore.Infrastructure.Contracts
{
    public interface IPublisherRepository<TKey, TExist, TStatus> : IBaseRepository<Publisher?, TKey, TExist, TStatus> { }
}
