using BookStore.Domain.Models;

namespace BookStore.Infrastructure.Contracts
{
    public interface IPublisherRepository<TKey> : IBaseRepository<Publisher, TKey> { }
}
