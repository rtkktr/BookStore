using BookStore.Domain.Models;

namespace BookStore.Infrastructure.Contracts
{
    public interface IOrderHeaderRepository<TKey, TExist, TStatus> : IBaseRepository<OrderHeader?, TKey, TExist, TStatus> { }
}
