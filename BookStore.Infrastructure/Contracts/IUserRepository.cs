using BookStore.Domain.Models;

namespace BookStore.Infrastructure.Contracts
{
    public interface IUserRepository<TKey> : IBaseRepository<User, TKey> { }
}
