using BookStore.Domain.Models;

namespace BookStore.Infrastructure.Contracts
{
    internal interface IOrderDetailRepository<TKey> : IBaseRepository<OrderDetail, TKey> { }
}
