using BookStore.Domain.Models;

namespace BookStore.Infrastructure.Contracts
{
    public interface IOrderHeaderRepository<TKey> : IBaseRepository<OrderHeader, TKey> { }
}
