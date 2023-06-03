using BookStore.Saas.Domain.Models;

namespace BookStore.Saas.Infrastructure.Contracts
{
    public interface IOrderHeaderRepository<TKey, TExist, TStatus> : IBaseRepository<OrderHeader?, TKey, TExist, TStatus> { }
}
