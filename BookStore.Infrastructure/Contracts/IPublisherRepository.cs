using BookStore.Domain.Models;

namespace BookStore.Infrastructure.Contracts
{
    public interface IPublisherRepository<TKey, TExist> : IBaseRepository<Publisher?, TKey, TExist> { }
}
