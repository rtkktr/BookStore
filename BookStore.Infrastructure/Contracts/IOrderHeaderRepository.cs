using BookStore.Domain.Models;

namespace BookStore.Infrastructure.Contracts
{
    public interface IOrderHeaderRepository<TKey, TExist> : IBaseRepository<OrderHeader?, TKey, TExist> { }
}
