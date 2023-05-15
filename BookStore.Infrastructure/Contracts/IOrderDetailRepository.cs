using BookStore.Domain.Models;

namespace BookStore.Infrastructure.Contracts
{
    internal interface IOrderDetailRepository<TKey, TExist> : IBaseRepository<OrderDetail?, TKey, TExist> { }
}
