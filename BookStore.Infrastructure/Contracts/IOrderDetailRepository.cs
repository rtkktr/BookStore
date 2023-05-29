using BookStore.Domain.Models;

namespace BookStore.Infrastructure.Contracts
{
    internal interface IOrderDetailRepository<TKey, TExist, TStatus> : IBaseRepository<OrderDetail?, TKey, TExist, TStatus> { }
}
