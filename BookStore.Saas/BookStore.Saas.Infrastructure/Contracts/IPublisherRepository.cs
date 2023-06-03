using BookStore.Saas.Domain.Models;

namespace BookStore.Saas.Infrastructure.Contracts
{
    public interface IPublisherRepository<TKey, TExist, TStatus> : IBaseRepository<Publisher?, TKey, TExist, TStatus> { }
}
