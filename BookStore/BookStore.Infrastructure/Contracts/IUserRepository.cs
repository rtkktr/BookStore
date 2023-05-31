using BookStore.Domain.Models;

namespace BookStore.Infrastructure.Contracts
{
    public interface IUserRepository<TKey, TExist, TStatus> : IBaseRepository<User?, TKey, TExist, TStatus> { }
}
