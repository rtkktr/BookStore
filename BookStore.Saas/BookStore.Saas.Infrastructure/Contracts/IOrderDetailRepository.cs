using BookStore.Saas.Domain.Models;

namespace BookStore.Saas.Infrastructure.Contracts
{
    internal interface IOrderDetailRepository<TKey, TExist, TStatus> : IBaseRepository<OrderDetail?, TKey, TExist, TStatus> { }
}
